using Microsoft.AspNetCore.Mvc;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Startingsetup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControl : ControllerBase
    {
        private ApplicationDbContext _context;//only used in this class dependency injection
        public UserControl(ApplicationDbContext context) { _context = context; }//create a overwrite by constructor


        // GET: api/<UserControl>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            List<User> users = _context.Users.ToList();

            return users;
        }//get all data

        // GET api/<UserControl>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            //hold data
            User user = _context.Users.Find(id);
            return user;
        }//get id data


        // POST api/<UserControl>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // PUT api/<UserControl>/5
        [HttpPut("{id}")]
        //update
        public ActionResult Put(int id, [FromBody]User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return NoContent();

        }

        // DELETE api/<UserControl>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            User user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
