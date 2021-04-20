using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GoogleNote.Core.Models;
using GoogleNote.Core.Services;

namespace GoogleNote.Controllers
{
    [Route("api/authenticate")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Auth
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            // return await _userService;
            return NotFound();
        }

        // GET: api/Auth/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            // var user = await _context.Users.FindAsync(id);

            // if (user == null)
            // {
            //     return NotFound();
            // }

            // return user;
            return NotFound();
        }

        // PUT: api/Auth/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            // if (id != user.Id)
            // {
            //     return BadRequest();
            // }

            // _context.Entry(user).State = EntityState.Modified;

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!UserExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            // return NoContent();
            return NotFound();
        }

        // POST: api/Auth
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            // _context.Users.Add(user);
            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetUser", new { id = user.Id }, user);
            return NotFound();
        }

        // DELETE: api/Auth/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            // var user = await _context.Users.FindAsync(id);
            // if (user == null)
            // {
            //     return NotFound();
            // }

            // _context.Users.Remove(user);
            // await _context.SaveChangesAsync();

            // return NoContent();
            return NotFound();
        }

        private bool UserExists(int id)
        {
            // return _context.Users.Any(e => e.Id == id);
            return true;
        }
    }
}
