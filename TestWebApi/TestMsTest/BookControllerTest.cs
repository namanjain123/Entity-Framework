using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Controllers;
using TestWebApi.Models;

namespace TestMsTest
{
    [TestClass]
    public class BookControllerTest
    {
        private new testwebapiContext _testContext;
        private Fixture _fixtures;
        private BookController _controller;
        public BookControllerTest()
        {
            var options = new DbContextOptionsBuilder<testwebapiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var _testContext = new testwebapiContext(options);
            _testContext.Database.EnsureCreated();
            _fixtures = new Fixture();
            var bookList = _fixtures.CreateMany<Book>(5).ToList();
            _testContext.Add(bookList);
        }
        [TestMethod]
        public async Task GetBookAllTest()
        {
            //Arrange
            _controller = new BookController(_testContext);
            //Act
            var result = await _controller.Get();
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }
        [TestMethod]
        public async Task Post_Book_ReturnOk()
        {
            //Arrange
            _controller = new BookController(_testContext);
            var data = _fixtures.Create<Book>();
            //Act
            var result= await  _controller.Post(data);
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }
        [TestMethod]
        public async Task Update_Book_ReturnOk()
        {
            //Arrange
            _controller = new BookController(_testContext);
            var data = _fixtures.Create<Book>();
            //Act
            var result = await _controller.Update(data);
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }
        [TestMethod]
        public async Task Delete_Book_ReturnOk()
        {
            //Arrange
            var bookList = _fixtures.Create<Book>();
            _controller = new BookController(_testContext);
            //Act
            var result = await _controller.Delete(bookList.BookId);
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }

    }
}
