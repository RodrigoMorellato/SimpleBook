using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBookApi.Dtos;
using SimpleBookApi.Services.Interfaces;
using SimpleBookApi.Validators;

namespace SimpleBookApi.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/book")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        /// <summary>
        /// Create new book at the database
        /// </summary>
        /// <remarks>
        /// 
        /// <h3>To create a new book the following fields cannot be duplicated:</h3>
        /// <ul>
        ///     <li>Name</li>
        ///     <li>Category</li>
        /// </ul>
        /// </remarks>
        /// <param name="bookDto"></param>
        /// <returns></returns>
        [HttpPost, Route("create")]
        [ProducesResponseType(typeof(int), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> CreateBook([FromBody][Bind("Name,Author,Registration,Categoria,Description")] CreateBookDto bookDto)
        {
            try
            {
                var validador = new BookDtoValidator();
                var resultado = validador.Validate(bookDto);
                if (!resultado.IsValid)
                    throw new ValidationException(resultado.ToString());

                var result = await _bookService.CreateBook(bookDto);
                return new CreatedResult("Book", result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The Book was not added.");
                return new BadRequestObjectResult($"The Book was not added. Message: {ex.Message}");
            }
        }

        /// <summary>
        /// Update book data
        /// </summary>
        /// <remarks>
        /// Example:
        ///
        ///     {
        ///         "name": "New Name",
        ///         "author": null,
        ///         "registration": null,
        ///         "category": null,
        ///         "description": null
        ///     }
        /// </remarks>
        /// <param name="bookId"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut, Route("{bookId:int}/update")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateBook(int bookId, [FromBody] EditBookDto book)
        {
            try
            {
                var result = await _bookService.UpdateBook(bookId, book);
                return new OkObjectResult(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The book was not updated.");
                return new BadRequestObjectResult($"The book was not updated. Message: {ex.Message}");
            }
        }

        /// <summary>
        /// Get all books
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("getall")]
        [ProducesResponseType(typeof(List<EditBookDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllBook()
        {
            try
            {
                var result = await _bookService.GetAllBook();
                return new CreatedResult("Book", result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "The Books were not charge.");
                return new BadRequestObjectResult($"The Books were not charge. Message: {ex.Message}");
            }
        }
    }
}
