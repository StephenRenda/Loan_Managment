﻿using System.Security.Claims;
using System.Threading.Tasks;
using App.Helpers;
using App.Managers;
using App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Members
        private readonly LoanAppDbContext _context;
        #endregion

        #region Constructor
        public AuthController(LoanAppDbContext context)
        {
            _context = context;
        }
        #endregion

        #region Public Methods
        [HttpPost("signin")]
        //POST: /auth/signin/
        public async Task<IActionResult> SignIn([Bind("Username,Password")] LoginRequestModel login)
        {
            //Find a user with a matching email as entered
            var foundUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Username == login.Username);

            //If no user was found, exit with error
            if(foundUser == null)
            {
                return Unauthorized(new { error = "User not found" });
            }

            //Otherwise, check the DB hash against our user's entered password's hash
            string loginPassHash = UserHelper.GeneratePasswordHash(login.Password, foundUser.Salt);
            bool authed = (foundUser.HashedPassword == loginPassHash);

            //If they failed to hash to the same value, return an error
            if (!authed)
            {
                return Unauthorized(new { error = "Password entered is incorrect" });
            }

            IAuthContainerModel model = new JWTContainerModel()
            {
                Claims = new Claim[]
                {
                    new Claim("UserName", foundUser.Username),
                    new Claim("IsAdmin", foundUser.IsAdmin.ToString())
                },
            };

            //Generate a JWT token for further authentication
            IAuthService jwt = new JWTService(model.SecretKey);
            string jwtToken = jwt.GenerateToken(model);

            //Add it as a cookie to the response
            Response.Cookies.Append("t", jwt.GenerateToken(model));

            //Return our JWT access token and the authenticated user's information
            //  Make a temporary user to strip out private info out of the user model (like passwords)
            UserModel returnUser = new UserModel
            {
                _id = foundUser._id,
                Username = foundUser.Username,
                FName = foundUser.FName,
                LName = foundUser.LName,
                Email = foundUser.Email,
            };
            return Ok(new { JWTAccessToken = jwtToken, User = returnUser});
        }

        [HttpGet("signout")]
        public IActionResult SignOut()
        {
            Response.Cookies.Delete("t");
            return Ok("Sign out successful!");
        }
        #endregion
    }
}
