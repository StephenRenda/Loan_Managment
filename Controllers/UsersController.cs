using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Models;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;

        private const int minimumPasswordLength = 6;
        #endregion

        #region Constructor
        public UsersController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Private Methods
        private bool UserExists(string id)
        {
            return _context.Users.Any(e => e.Email == id);
        }
        #endregion

        #region Public Methods
        // GET: api/users/
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _context.Users.ToListAsync());
        }

        // GET: api/users/{id}
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

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m._id == idGuid);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: api/users/
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Username,FName,LName,IsAdmin,Password")] UserModel user)
        {
            // Validate password format and length
            if(user.Password.Length < minimumPasswordLength)
            {
                return BadRequest(new { error = "Password must be at least 6 characters long" });
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                } catch (Exception)
                {
                    return BadRequest(new { error = "There was an error creating your account. Please contact support."});
                }
                return RedirectToAction(nameof(Index));
            }
            return Ok(user);
        }

        // POST: api/users/edit?id={id}
        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(string id, [Bind("Username,Email,Name,IsAdmin,HashedPassword,Salt")] UserModel user)
        {
            if (id != user._id.ToString())
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Email))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return Ok(user);
        }

        // POST: api/users/delete?id={id}
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

            //Make sure the ID associates with a user
            var user = await _context.Users.FindAsync(idGuid);
            if(user == null)
            {
                return NotFound();
            }

            //If we get here, the user exists. Delete them.
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            
            //Redirect to the index
            return RedirectToAction(nameof(Index));
        }
        #endregion
    }
}
