using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : ControllerBase
    { 
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public LoansController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/loans/5
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

            var loan = await _context.Loans
                .FirstOrDefaultAsync(m => m.ID == idGuid);

            if (loan == null)
            {
                return NotFound();
            }

            return Ok(loan);
        }

        [HttpPost("search")]
        public async Task<IActionResult> Search(string type, string searchString)
        {

            switch(type)
            {
                case ("BorrowerName"):
                    var loans = await _context.Loans.Where(loan => loan.Borrower.Fname.Contains(searchString) || loan.Borrower.Lname.Contains(searchString)).ToListAsync();
                    if(loans == null || loans.Count() == 0)
                    {
                        return NotFound();
                    }
                    return Ok(loans);
                case ("LoanNumber"):
                    var loan = await _context.Loans.Where(loan => loan.LoanNumber == searchString).FirstAsync();
                    if(loan == null)
                    {
                        return NotFound();
                    }
                    return Ok(loan);
                case ("PropertyAddress"):
                    //TODO: After PropertyAddress or Property Model is added
                default:
                    return BadRequest();
            }
        }

        [HttpGet("recent/{numRecords}")] 
        public async Task<IActionResult> Recent(int numRecords)
        {
            var loans = await _context.Loans.OrderBy(x => x.LastChangedOn).Take(numRecords).ToListAsync();
            return Ok(loans);
        }

        // POST api/loans
        [HttpPost]
        public async Task<IActionResult> Create(LoanModel loan) 
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(loan);
                    await _context.SaveChangesAsync();
                } catch(Exception)
                {
                    return BadRequest(new { error = "There was an error creating this loan" });
                }
            }
            return Ok(loan);
        }

        // POST api/loans/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, LoanModel loan)
        { 
            if (id != loan.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(loan);
        }

        //POST: api/loans/delete?id=5
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

            var loan = await _context.Loans.FindAsync(idGuid);
            if (loan != null) {
                _context.Loans.Remove(loan);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
