using System.Linq.Expressions;

namespace SimpleBookApi.Repositories.Interfaces
{
    public interface IRepositoryGeneric<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<TEntity> DeleteAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filtro, bool @somenteLeitura = false);
        Task<bool> ExistAnyAsync(Expression<Func<TEntity, bool>> filtro);
        Task SaveChanges();
    }
}
