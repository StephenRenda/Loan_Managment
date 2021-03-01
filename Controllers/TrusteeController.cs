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
    public class TrusteeController : Controller
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public TrusteeController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/borrowers/5
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

            var trustee = await _context.Trustees
                .FirstOrDefaultAsync(m => m.ID == idGuid);
            if (trustee == null)
            {
                return NotFound();
            }

            return Ok(trustee);
        }

        // POST api/borrowers
        [HttpPost]
        public async Task<IActionResult> Create(TrusteeModel trustee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(trustee);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this trustee" });
                }
            }
            return Ok(trustee);
        }

        // POST api/borrowers/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, TrusteeModel trustee)
        {
            if (id != trustee.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trustee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(trustee);
        }

        //POST: api/borrowers/delete?id=5
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

            var trustee = await _context.Trustees.FindAsync(idGuid);
            if (trustee != null)
            {
                _context.Trustees.Remove(trustee);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
