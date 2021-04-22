using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoogleNote.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace GoogleNote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class NoteController : ControllerBase
    {
        private DatabaseContext _ctx;
        private User _authUser;

        public NoteController(DatabaseContext context)
        {
            this._ctx = context;
            _authUser = (User)HttpContext.Items["User"];
        }

        [HttpGet]
        public async Task<IEnumerable<Note>> All()
        {
            return await _ctx.Notes
                .Where(note => note.UserId == _authUser.Id)
                .OrderBy(note => note.Id)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetById(int id)
        {
            var note = await _ctx.Notes.FindAsync(id);

            if (note == null)
            {
                return NotFound();
            }

            if (note.UserId != _authUser.Id)
            {
                new JsonResult(new { message = "Unauthorized" }) { StatusCode = StatusCodes.Status401Unauthorized };
            }

            return note;
        }

        [HttpPost]
        public async Task<ActionResult<Note>> AddAsync(Note entity)
        {
            entity.UserId = _authUser.Id;
            _ctx.Set<Note>().Add(entity);
            await _ctx.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetById),
                new { id = entity.Id },
                entity
            );
        }

        [HttpPut]
        public async Task<ActionResult<Note>> UpdateAsync(Note entity)
        {
            var currentNote = await _ctx.Set<Note>().FindAsync(entity.Id);
            
            if (currentNote == null) {
                return NotFound();
            }            

            currentNote.Title = entity.Title;
            currentNote.Description = entity.Description;
            currentNote.CreatedAt = DateTime.Now;
            currentNote.UpdatedAt = DateTime.Now;

            await _ctx.SaveChangesAsync();
            return currentNote;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> Delete(int id)
        {
            var note = _ctx.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            note.DeletedAt = DateTime.Now;
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
