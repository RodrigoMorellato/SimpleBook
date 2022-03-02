using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SimpleBookApi.Controllers;
using SimpleBookApi.Dtos;
using SimpleBookApi.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SimpleBookApiTests.Controllers
{
    [TestClass()]
    public class BookControllerTests
    {
        private readonly Mock<ILogger<BookController>> _loggerMock;
        private readonly Mock<IBookService>  _bookServiceMock;

        public BookControllerTests()
        {
            _loggerMock = new Mock<ILogger<BookController>>();
            _bookServiceMock = new Mock<IBookService>();
        }

        [TestMethod()]
        public async Task CreateBookTest()
        {
            //Arrange
            var controller = new BookController(_loggerMock.Object, _bookServiceMock.Object);
            _bookServiceMock.Setup(m => m.CreateBook(It.IsAny<BookDto>())).Callback(() => { }).Returns(() => Task.Run(() =>
            {
                var result = InstatiateNewBookFull();
                result.Id = 1;
                return result;
            }));
            var bookDto = InstatiateNewBookFull();

            //Action
            var result = await controller.CreateBook(bookDto);
            var actual = (result as CreatedResult)?.Value;

            //Assert
            Assert.AreEqual(1, actual);
        }

        [TestMethod()]
        public async Task CreateBookFailTest()
        {
            //Arrange
            var controller = new BookController(_loggerMock.Object, _bookServiceMock.Object);
            _bookServiceMock.Setup(m => m.CreateBook(It.IsAny<BookDto>())).Callback(() => { }).Returns(() => throw new Exception("Fail"));
            var bookDto = InstatiateNewBookFull();

            //Action
            var result = await controller.CreateBook(bookDto);
            var actual = (result as BadRequestObjectResult)?.Value;

            //Assert
            Assert.AreEqual("The Book was not added. Message: Fail", actual);
        }

        [TestMethod()]
        public async Task UpdateBookTest()
        {
            //Arrange
            var controller = new BookController(_loggerMock.Object, _bookServiceMock.Object);
            _bookServiceMock.Setup(m => m.UpdateBook(It.IsAny<int>(),
                It.IsAny<BookDto>())).Callback(() => { }).Returns(() => Task.Run(() => InstatiateNewBook()));
            var bookDto = InstatiateNewBook();

            //Action
            var result = await controller.UpdateBook(1, bookDto);
            var actual = (result as OkObjectResult)?.Value as BookDto;

            //Assert
            Assert.AreEqual(bookDto.Name, actual?.Name);
        }

        [TestMethod()]
        public async Task UpdateBookFailTest()
        {
            //Arrange
            var controller = new BookController(_loggerMock.Object, _bookServiceMock.Object);
            _bookServiceMock.Setup(m => m.UpdateBook(It.IsAny<int>(), 
                It.IsAny<BookDto>())).Callback(() => { }).Returns(() => throw new Exception("Fail"));
            var bookDto = InstatiateNewBook();

            //Action
            var result = await controller.UpdateBook(1, bookDto);
            var actual = (result as BadRequestObjectResult)?.Value;

            //Assert
            Assert.AreEqual("The book was not updated. Message: Fail", actual);
        }

        #region PrivateMethods

        private static BookDto InstatiateNewBook()
        {
            return new BookDto("Alter name test.", null, null, null, null);
        }

        private static BookDto InstatiateNewBookFull()
        {
            return new BookDto(
                "Tomorrow's sun",
                "Loriel",
                "AD45FTY3",
                "Drama",
                "Description test"
            );
        }

        #endregion
    }
}