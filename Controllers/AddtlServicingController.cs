using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddtlServicingController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public AddtlServicingController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/addtlservicing/5
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

            var addtlservicing = await _context.AddtlServicing
                .FirstOrDefaultAsync(m => m.ID == idGuid);
            if (addtlservicing == null)
            {
                return NotFound();
            }

            return Ok(addtlservicing);
        }

        // POST api/addtlservicing
        [HttpPost]
        public async Task<IActionResult> Create(AddtlServicingModel addtlservicing)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(addtlservicing);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this addtlservicing" });
                }
            }
            return Ok(addtlservicing);
        }

        // POST api/addtlservicing/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, AddtlServicingModel addtlservicing)
        {
            if (id != addtlservicing.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addtlservicing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(addtlservicing);
        }

        //POST: api/addtlservicing/delete?id=5
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

            var addtlservicing = await _context.AddtlServicing.FindAsync(idGuid);
            if (addtlservicing != null)
            {
                _context.AddtlServicing.Remove(addtlservicing);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
