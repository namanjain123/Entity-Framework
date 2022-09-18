using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebApi.Models;

namespace TestWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        //using injection
        private readonly testwebapiContext context;
        public BookController(testwebapiContext _context)
        {
            context = _context;
        }
        
        //[HttpGet]
        //public IEnumerable<Book> Get()
        //{
        //        return context.Book.ToList();
        //}
        //[HttpGet("{id}")]
        //public IEnumerable<Book> Get(int id)
        //{
        //    using (var context = new testwebapiContext())
        //    {
        //        // get all authors
        //        // return context.Author.ToList ( ) ;
        //        // get author by id
        //        return context.Book.Where(a=>a.BookId==id).ToList();
        //    }
        //}

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var c = context.Book;
            return StatusCode(200, c);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var hero = await context.Book.FindAsync(id);
            if (hero == null)
                return BadRequest("Book Not Found");
            return StatusCode(200, hero);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Book book)
        {
            context.Book.Add(book);
            await context.SaveChangesAsync();
            var c = context.Book ;
            return StatusCode(200,c);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Book request)
        {
            var dbHero = await context.Book.FindAsync(request.BookId);
            if (dbHero == null)
                return StatusCode(200);

            dbHero.Price = request.Price;
            dbHero.PubId = request.PubId;
            dbHero.PublishedDate = request.PublishedDate;
            dbHero.Title = request.Title;

            await context.SaveChangesAsync();
            var c = context.Book;
            return StatusCode(200, c);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dbHero = await context.Book.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Book not found.");

            context.Book.Remove(dbHero);
            await context.SaveChangesAsync();
            var c = context.Book;
            return StatusCode(200, c);
        }
        public int getsum(int a, int b)
        {
            int sum = a + b;
            return sum;
        }
    }
}
