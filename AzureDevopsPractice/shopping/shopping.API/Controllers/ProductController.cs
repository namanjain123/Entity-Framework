using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shopping.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shopping.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            //var rng = new Random();
            //return Enumerable.Range(1, 5)
            //    .Select(
            //    index => new Product
            //{
            //    Name="Naman"
            //}
            //)
            //.ToArray();
            return ProductContext.Products;
        }
    }
}
