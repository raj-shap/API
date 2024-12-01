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

            //if(user.Password != user.ConfirmPassowrd)
            //{
            //    return BadRequest("Password and Confirm passoword must be same.");
            //}
            string encryptedPassword = UserAuth.EncryptSec(user.Password);
            //string encryptedConfirmPassword = UserAuth.EncryptSec(user.ConfirmPassowrd);
            user.Password = encryptedPassword;
            //user.ConfirmPassowrd = encryptedConfirmPassword;

            //Generate a unique ID for the user
            user.UserID = IdGenerator.GenerateUniqueId();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

    }
}
