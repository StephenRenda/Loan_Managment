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
    public class BorrowersController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public BorrowersController(LoanAppDbContext context)
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
            } catch
            {
                return BadRequest();
            }

            var borrower = await _context.Borrowers
                .FirstOrDefaultAsync(m => m.ID == idGuid);

            if (borrower == null)
            {
                return NotFound();
            }

            return Ok(borrower);
        }

        // POST api/borrowers
        [HttpPost]
        public async Task<IActionResult> Create(BorrowerModel borrower) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(borrower);
                    await _context.SaveChangesAsync();
                } catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this borrower" });
                }
            }
            return Ok(borrower);
        }

        // POST api/borrowers/edit?id={id}
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, BorrowerModel borrower)
        { 
            if (id != borrower.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(borrower);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(borrower);
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
            } catch
            {
                return BadRequest();
            }

            var borrower = await _context.Borrowers.FindAsync(idGuid);
            if (borrower != null) {
                _context.Borrowers.Remove(borrower);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
