using Microsoft.EntityFrameworkCore;
using SimpleBookApi.Models;
using SimpleBookApi.Repositories.Interfaces;
using System.Linq.Expressions;
using SimpleBookApi.Repositories.Configuration;

namespace SimpleBookApi.Repositories
{
    public class RepositoryGeneric<TEntity> : IRepositoryGeneric<TEntity> where TEntity : class
    {
        private readonly ApiContext _apiContext;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryGeneric(ApiContext context)
        {
            _apiContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
            return entity;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));
            return entity;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id) ?? throw new KeyNotFoundException("Entity not found.");
        }

        public async Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filtro, bool isReading = false)
        {
            return await Task.Run(() => isReading
                ? _dbSet.Where(filtro).AsNoTracking().ToListAsync()
                : _dbSet.Where(filtro).ToListAsync());
        }

        public async Task<bool> ExistAnyAsync(Expression<Func<TEntity, bool>> filtro)
        {
            return await _dbSet.AnyAsync(filtro);
        }

        public async Task SaveChanges()
        {
            await _apiContext.SaveChangesAsync();
        }
    }
}
