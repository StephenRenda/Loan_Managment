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
    public class EscrowController : Controller
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public EscrowController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/escrows/5
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

            var escrow = await _context.Escrows
                .FirstOrDefaultAsync(m => m.ID == idGuid);
            if (escrow == null)
            {
                return NotFound();
            }

            return Ok(escrow);
        }

        // POST api/escrows
        [HttpPost]
        public async Task<IActionResult> Create(EscrowModel escrow)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(escrow);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this deduction" });
                }
            }
            return Ok(escrow);
        }

        // POST api/escrows/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, EscrowModel escrow)
        {
            if (id != escrow.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(escrow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(escrow);
        }

        //POST: api/escrows/delete?id=5
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

            var escrow = await _context.Escrows.FindAsync(idGuid);
            if (escrow != null)
            {
                _context.Escrows.Remove(escrow);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
