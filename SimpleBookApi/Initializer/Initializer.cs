using Microsoft.EntityFrameworkCore;
using SimpleBookApi.Dtos;
using SimpleBookApi.Enums;
using SimpleBookApi.Models;
using SimpleBookApi.Repositories;
using SimpleBookApi.Repositories.Configuration;
using SimpleBookApi.Repositories.Interfaces;
using SimpleBookApi.Services;
using SimpleBookApi.Services.Interfaces;

namespace SimpleBookApi.Initializer
{
    public class Initializer
    {
        internal static void Configure(IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Add dbcontext
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("LibraryDb"));

            //Repos
            services.AddScoped(typeof(IRepositoryGeneric<>), typeof(RepositoryGeneric<>));
            services.AddScoped(typeof(IBookRepository), typeof(BookRepository));

            //Services
            services.AddScoped(typeof(IBookService), typeof(BookService));
        }

        internal static void AddTestData(DbContextOptions<ApiContext> options)
        {

            using var context = new ApiContext(options);
            context.Book.Add(InstatiateNewBook());

            context.SaveChanges();
        }

        private static Book InstatiateNewBook()
        {
            return new Book(
                "Tomorrow's sun",
                "Loriel",
                DateTime.Now,
                EnumCategory.Drama,
                "Description test"
            );
        }
    }
}
