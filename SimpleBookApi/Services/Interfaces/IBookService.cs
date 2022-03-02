using SimpleBookApi.Dtos;
using SimpleBookApi.Models;

namespace SimpleBookApi.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> GetBook(int id);
        Task<List<EditBookDto>> GetAllBook();
        Task<int> CreateBook(BookDto bookDto);
        Task<BookDto> UpdateBook(int id, BookDto bookDto);
    }
}
