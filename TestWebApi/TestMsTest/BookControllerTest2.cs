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
    public class BookControllerTest2
    {
       
        public testwebapiContext GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<testwebapiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new testwebapiContext(options);
            databaseContext.Database.EnsureCreated();
            databaseContext.Add(new Book { BookId = 1, Title = "naman", Type = "fiction", PubId = 2, Price = 2000, PublishedDate = new DateTime(2012, 12, 25, 10, 30, 50) });
            return databaseContext;
        }
        [TestMethod]
        public async Task GetBookAllTest()
        {
            var dbContext = GetDatabaseContext();
            var controller = new BookController(dbContext);
            //Act
            var result = await controller.Get();
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }
        [TestMethod]
        public async Task Post_Book_ReturnOk()
        {
            //Arrange
            var dbContext = GetDatabaseContext();
            var controller = new BookController(dbContext);
            Book c = new Book();
            //Act
            var result = await controller.Post(c);
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }
        [TestMethod]
        public async Task Update_Book_ReturnOk()
        {
            //Arrange
            var dbContext = GetDatabaseContext();
            var controller = new BookController(dbContext);
            Book c = new Book { BookId = 1, Title = "naman", Type = "fiction", PubId = 2, Price = 2000, PublishedDate = new DateTime(2012, 12, 25, 10, 30, 50) };
            //Act
            var result = await controller.Update(c);
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }
        [TestMethod]
        public async Task Delete_Book_ReturnOk()
        {
            var dbContext = GetDatabaseContext();
            var controller = new BookController(dbContext);
            //Act
            var result = await controller.Delete(1);
            var obj = result as ObjectResult;
            //Assert
            Assert.AreEqual(obj.StatusCode, 200);
        }

    }
}
