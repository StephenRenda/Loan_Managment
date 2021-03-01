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
    public class CostExpenseController : Controller
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public CostExpenseController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/costexpenses/5
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

            var costexpense = await _context.CostExpenses
                .FirstOrDefaultAsync(m => m.ID == idGuid);
            if (costexpense == null)
            {
                return NotFound();
            }

            return Ok(costexpense);
        }

        // POST api/costexpenses
        [HttpPost]
        public async Task<IActionResult> Create(CostExpenseModel costexpense)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(costexpense);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this costexpense" });
                }
            }
            return Ok(costexpense);
        }

        // POST api/costexpenses/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, CostExpenseModel costexpense)
        {
            if (id != costexpense.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(costexpense);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(costexpense);
        }

        //POST: api/costexpenses/delete?id=5
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

            var costexpense = await _context.CostExpenses.FindAsync(idGuid);
            if (costexpense != null)
            {
                _context.CostExpenses.Remove(costexpense);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
