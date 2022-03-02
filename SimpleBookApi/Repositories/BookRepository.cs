using SimpleBookApi.Models;
using SimpleBookApi.Repositories.Configuration;
using SimpleBookApi.Repositories.Interfaces;

namespace SimpleBookApi.Repositories
{
    internal class BookRepository : RepositoryGeneric<Book>, IBookRepository
    {
        public BookRepository(ApiContext context) : base(context)
        {
        }
    }
}
