using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public AssignmentController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/assignment/5
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

            var property = await _context.Assignments
                .FirstOrDefaultAsync(m => m.ID == idGuid);

            if (property == null)
            {
                return NotFound();
            }

            return Ok(property);
        }

        // POST api/note
        [HttpPost]
        public async Task<IActionResult> Create(AssignmentModel assignment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this property" });
                }
            }
            return Ok(assignment);
        }

        // POST api/assignment/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, AssignmentModel assignment)
        {
            if (id != assignment.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(assignment);
        }

        //POST: api/assignment/delete?id=5
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

            var assignment = await _context.Assignments.FindAsync(idGuid);
            if (assignment != null)
            {
                _context.Assignments.Remove(assignment);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
