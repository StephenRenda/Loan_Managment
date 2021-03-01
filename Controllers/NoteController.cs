using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public NoteController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/note/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(string id)
        {
            //Check if the entered ID is valid
            if (id == null)
            {
                return NotFound();
            }

            //Check if the provided ID is a valid Guid
            Guid idGuid;
            try
            {
                idGuid = Guid.Parse(id);
            }
            catch
            {
                return BadRequest();
            }

            var note = await _context.Notes
                .FirstOrDefaultAsync(m => m.ID == idGuid);

            if (note == null)
            {
                return NotFound();
            }

            return Ok(note);
        }

        // POST api/note
        [HttpPost]
        public async Task<IActionResult> Create(NoteModel note)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(note);
                    await _context.SaveChangesAsync();
                } catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this note" });
                }
            }
            return Ok(note);
        }

        // POST api/note/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, NoteModel note)
        {
            if (id != note.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(note);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(note);
        }

        //POST: api/note/delete?id=5
        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            //Check if the provided ID is a valid Guid
            Guid idGuid;
            try
            {
                idGuid = Guid.Parse(id);
            }
            catch
            {
                return BadRequest();
            }

            var note = await _context.Notes.FindAsync(idGuid);
            if (note != null)
            {
                _context.Notes.Remove(note);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
