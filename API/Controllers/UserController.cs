using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
using Azure.Messaging;
using Microsoft.AspNetCore.Identity;
using API.DTO;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<User>> CreateUser(User_DTO user_dto)
        {
            if (user_dto == null)
            {
                return BadRequest("User Data is required.");
            }
            bool userExist = await context.Users.AnyAsync(u => u.Email == user_dto.dto_Email || u.phone == user_dto.dto_phone);

            if (userExist)
            {
                return BadRequest("A user is already registered with email or phone");
            }

            if(user_dto.dto_Password != user_dto.dto_ConfirmPassowrd)
            {
                return BadRequest("Password and Confirm Password must be same.");
            }
            var user = new User()
            {
                UserID = IdGenerator.GenerateUniqueId(),
                Name = user_dto.dto_Name,
                Email = user_dto.dto_Email,
                Role = user_dto.dto_Role,
                UserName = user_dto.dto_UserName,
                phone = user_dto.dto_phone,
                Password = UserAuth.EncryptSec(user_dto.dto_Password),
                CreatedOn = DateTime.Now,
                CreatedBy = user_dto.dto_CreatedBy,
                ModifiedOn = DateTime.Now,
                ModifiedBy = user_dto.dto_ModifiedBy,

            };
            //user.CreatedOn = DateTime.Now;
            //user.ModifiedOn = DateTime.Now;

            ////if(user.Password != user.ConfirmPassowrd)
            ////{
            ////    return BadRequest("Password and Confirm passoword must be same.");
            ////}
            //string encryptedPassword = UserAuth.EncryptSec(user.Password);
            ////string encryptedConfirmPassword = UserAuth.EncryptSec(user.ConfirmPassowrd);
            //user.Password = encryptedPassword;
            ////user.ConfirmPassowrd = encryptedConfirmPassword;

            ////Generate a unique ID for the user
            //user.UserID = IdGenerator.GenerateUniqueId();
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }

        

    }
}
