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
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // POST: api/authenticate
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("login")]
        public async Task<ActionResult> Login(User entity)
        {
            var response = _authService.Login(entity.Email, entity.Password);

            // return CreatedAtAction("GetUser", new { id = user.Id }, user);
            if (response == null) {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(User entity)
        {
            var user = await _authService.Register(entity.Email, entity.Password);

            return user;
        }

        private bool UserExists(int id)
        {
            // return _context.Users.Any(e => e.Id == id);
            return true;
        }
    }
}
