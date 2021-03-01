using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductionController : Controller
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public DeductionController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/deductions/5
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

            var deduction = await _context.Deductions
                .FirstOrDefaultAsync(m => m.ID == idGuid);
            if (deduction == null)
            {
                return NotFound();
            }

            return Ok(deduction);
        }

        // POST api/deductions
        [HttpPost]
        public async Task<IActionResult> Create(DeductionModel deduction)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(deduction);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this deduction" });
                }
            }
            return Ok(deduction);
        }

        // POST api/deductions/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, DeductionModel deduction)
        {
            if (id != deduction.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deduction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(deduction);
        }

        //POST: api/deductions/delete?id=5
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

            var deduction = await _context.Deductions.FindAsync(idGuid);
            if (deduction != null)
            {
                _context.Deductions.Remove(deduction);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
