using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Controllers;
using TestWebApi.Models;
using Xunit;

namespace Testing
{
    public class UnitTest1
    {
        // Making Dumies DataBase
        private async Task<testwebapiContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<testwebapiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new testwebapiContext(options);
            databaseContext.Database.EnsureCreated();
            return databaseContext;
        }
        [Fact]
        public async Task TestGetAll()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var controller = new BookController(dbContext);
            //Act
            var result = controller.Get();
            //Arrange
            Assert.IsType<Task<ActionResult<List<Book>>>>(result);
        }

        [Fact]
        public async void TestGetById()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var controller = new BookController(dbContext);
            //Act
            var result = controller.Get(1);
            //Arrange
            Assert.IsType<Task<ActionResult<Book>>>(result);
        }

        [Fact]
        public async void TestPost()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var controller = new BookController(dbContext);
            Book c = new Book();
            //Act
            var result = controller.Post(c);
            //Assert
            Assert.IsType<Task<ActionResult<List<Book>>>>(result);
        }
        [Fact]
        public async void testUpdate()

        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var controller = new BookController(dbContext);
            Book c = new Book();
            //Act
            var result = controller.Update(c);
            //Assert
            Assert.IsType<Task<ActionResult<List<Book>>>>(result);
        }
        [Fact]
        public async void testDelete()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var controller = new BookController(dbContext);
            //Act
            var result = controller.Delete(1);
            //Assert
            Assert.IsType<Task<ActionResult<List<Book>>>>(result);
        }

    }
}
