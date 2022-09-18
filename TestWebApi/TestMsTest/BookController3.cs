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
    public class BookControllerTest3
    {
        private new testwebapiContext _testContext;
        private Fixture _fixtures;
        private BookController _controller;
        public BookControllerTest3()
        {
            var options = new DbContextOptionsBuilder<testwebapiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            _testContext = new testwebapiContext(options);
            _testContext.Database.EnsureCreated();
            _fixtures = new Fixture();
            _testContext.Add(new Book { BookId = 1, Title = "naman", Type = "fiction", PubId = 2, Price = 2000, PublishedDate = new DateTime(2012, 12, 25, 10, 30, 50) });
            
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
            var result = await _controller.Post(data);
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }
        [TestMethod]
        public async Task Update_Book_ReturnOk()
        {
            //Arrange
            _controller = new BookController(_testContext);
            var data = new Book { BookId = 1, Title = "naman", Type = "fiction", PubId = 2, Price = 2000, PublishedDate = new DateTime(2012, 12, 25, 10, 30, 50) };
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
            _controller = new BookController(_testContext);
            //Act
            var result = await _controller.Delete(1);
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }

    }
}
