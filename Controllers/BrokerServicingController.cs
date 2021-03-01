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
    public class BrokerServicingController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public BrokerServicingController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        // GET: api/brokerservicing/5
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

            var brokerservicing = await _context.BrokerServicing
                .FirstOrDefaultAsync(m => m.ID == idGuid);
            if (brokerservicing == null)
            {
                return NotFound();
            }

            return Ok(brokerservicing);
        }

        // POST api/brokerservicing
        [HttpPost]
        public async Task<IActionResult> Create(BrokerServicingModel brokerservicing)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(brokerservicing);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating this brokerservicing" });
                }
            }
            return Ok(brokerservicing);
        }

        // POST api/brokerservicing/5
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, BrokerServicingModel brokerservicing)
        {
            if (id != brokerservicing.ID.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brokerservicing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }
            }
            return Ok(brokerservicing);
        }

        //POST: api/brokerservicing/delete?id=5
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

            var brokerservicing = await _context.BrokerServicing.FindAsync(idGuid);
            if (brokerservicing != null)
            {
                _context.BrokerServicing.Remove(brokerservicing);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
