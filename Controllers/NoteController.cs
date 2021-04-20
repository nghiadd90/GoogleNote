using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GoogleNote.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GoogleNote.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : ControllerBase
    {
        private DatabaseContext _ctx;

        public NoteController(DatabaseContext context)
        {
            this._ctx = context;
        }

        [HttpGet]
        public async Task<IEnumerable<Note>> All()
        {
            return await _ctx.Notes.OrderBy(note => note.Id).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetById(long id)
        {
            return await _ctx.Notes.FindAsync(id) ?? new ActionResult<Note>(NotFound());
        }

        [HttpPost]
        public async Task<ActionResult<Note>> AddAsync(Note entity)
        {
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
            currentNote.CreatedAt = entity.CreatedAt;
            currentNote.UpdatedAt = entity.UpdatedAt;

            await _ctx.SaveChangesAsync();
            return currentNote;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Note>> Delete(long id)
        {
            var note = _ctx.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            _ctx.Notes.Remove(note);
            await _ctx.SaveChangesAsync();

            return NoContent();
        }
    }
}
