using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
using Azure.Messaging;
using Microsoft.AspNetCore.Identity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext context;
        public UserController(MyDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest("User Data is required.");
            }
            user.CreatedOn = DateTime.Now.ToString();
            user.ModifiedBy = DateTime.Now.ToString();

            if(user.Password != user.ConfirmPassowrd)
            {
                return BadRequest("Password and Confirm passoword must be same.");
            }

            var passwordHasher = new PasswordHasher<object>();
            string hashedPassword = passwordHasher.HashPassword(null, user.Password);
            string hashedConfirmPassword = passwordHasher.HashPassword(null, user.ConfirmPassowrd);
            var resultPassword = passwordHasher.VerifyHashedPassword(null, hashedPassword, user.Password);
            var resultConfirmPassword = passwordHasher.VerifyHashedPassword(null, hashedConfirmPassword, user.ConfirmPassowrd);
            if(resultPassword != PasswordVerificationResult.Success && resultConfirmPassword != PasswordVerificationResult.Success)
            {
                return BadRequest("issue in hashing passwored");
            }
            user.Password = hashedPassword;
            user.ConfirmPassowrd = hashedConfirmPassword;

            //Generate a unique ID for the user
            user.UserID = IdGenerator.GenerateUniqueId();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

    }
}
