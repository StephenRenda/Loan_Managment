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
    public class FinanceChargeController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public FinanceChargeController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/financecharge/5
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

            var financecharge = await _context.FinanceCharges
                .FirstOrDefaultAsync(m => m.ID == idGuid);
            if (financecharge == null)
            {
                return NotFound();
            }

            return Ok(financecharge);
        }

        // POST api/financecharge
        [HttpPost]
        public async Task<IActionResult> Create(FinanceChargeModel finCharge)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(finCharge);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this financecharge" });
                }
            }
            return Ok(finCharge);
        }

        // POST api/financecharge/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, FinanceChargeModel finCharge)
        {
            if (id != finCharge.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(finCharge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(finCharge);
        }

        //POST: api/financecharge/delete?id=5
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

            var financecharge = await _context.FinanceCharges.FindAsync(idGuid);
            if (financecharge != null)
            {
                _context.FinanceCharges.Remove(financecharge);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
