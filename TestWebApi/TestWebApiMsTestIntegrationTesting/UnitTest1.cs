using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using TestWebApi;

namespace TestWebApiMsTestIntegrationTesting
{
    [TestClass]
    public class UnitTest1
    {
        private readonly HttpClient _clinet;
        public UnitTest1()
        {
            var appFactory = new WebApplicationFactory<Startup>();
            _clinet = appFactory.CreateClient();

        }

        [TestMethod]
        [DataRow("/book")]
        [DataRow("/weatherforecast")]
        public async Task TestIntegrationTestingOfTheApiUrl(string url)
        {
            ///Act
            var response = await _clinet.GetAsync(url);
            //Assert
            response.EnsureSuccessStatusCode();
            Assert.AreEqual("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
        }
    }
}
