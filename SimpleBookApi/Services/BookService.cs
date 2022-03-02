
using System.Reflection;
using System.Text;
using AutoMapper;
using SimpleBookApi.Dtos;
using SimpleBookApi.Models;
using SimpleBookApi.Repositories.Interfaces;
using SimpleBookApi.Services.Interfaces;

namespace SimpleBookApi.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> GetBook(int id)
        {
            return _mapper.Map<EditBookDto>(await _bookRepository.GetByIdAsync(id));
        }

        public async Task<List<EditBookDto>> GetAllBook()
        {
            return _mapper.Map<List<EditBookDto>>(await _bookRepository.GetByFilterAsync(b => true));
        }

        public async Task<int> CreateBook(BookDto bookDto)
        {
            if (await _bookRepository.ExistAnyAsync(b => b.Name.Equals(bookDto.Name) && b.Category.Equals(bookDto.Category)))
                throw new AmbiguousMatchException("The book is already registered.");

            var result = await _bookRepository.AddAsync(_mapper.Map<Book>((CreateBookDto)bookDto));
            await _bookRepository.SaveChanges();
            return result.Id;
        }

        public async Task<BookDto> UpdateBook(int id, BookDto bookDto)
        {
            var entity = _mapper.Map(bookDto, await _bookRepository.GetByIdAsync(id));
            if (entity == null)
                throw new KeyNotFoundException("Entity not found.");

            var result = await _bookRepository.UpdateAsync(entity);
            await _bookRepository.SaveChanges();
            return _mapper.Map<EditBookDto>(await GetBook(result.Id));
        }
    }
}
