using Microsoft.EntityFrameworkCore;
using SimpleBookApi.Models;

namespace SimpleBookApi.Repositories.Configuration
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Book> Book => Set<Book>();
    }
}
