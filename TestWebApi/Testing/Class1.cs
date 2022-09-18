using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestWebApi.Controllers;
using TestWebApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Xunit;

namespace Testing
{
    [TestClass]
    public class Class1
    {
        private async Task<testwebapiContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<testwebapiContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            var databaseContext = new testwebapiContext(options);
            databaseContext.Database.EnsureCreated();
            databaseContext.Add(new Book {BookId=1,Title="naman",Type="fiction",PubId=2,Price=2000,PublishedDate= new DateTime(2012, 12, 25, 10, 30, 50) });
            return databaseContext;
        }
        [TestMethod]
        public async Task TestGetAll()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var controller = new BookController(dbContext);
            //Act
            var result = controller.getsum(2, 3);
            //var newresult = controller.Get();
            //OkObjectResult okResult = newresult.Value;
            //Arrange
            Assert.AreEqual(result, 5);



        }
    }
}
