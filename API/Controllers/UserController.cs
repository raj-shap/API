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
        [HttpPost("Reginstration")]
        public async Task<ActionResult<User>> CreateUser(Registration_DTO registration_dto)
        {
            if (registration_dto == null)
            {
                return BadRequest("User Data is required.");
            }
            bool userExist = await context.Users.AnyAsync(u => u.Email == registration_dto.dto_Email || u.phone == registration_dto.dto_phone);

            if (userExist)
            {
                return BadRequest("A user is already registered with email or phone");
            }

            if(registration_dto.dto_Password != registration_dto.dto_ConfirmPassowrd)
            {
                return BadRequest("Password and Confirm Password must be same.");
            }
            var user = new User()
            {
                UserID = IdGenerator.GenerateUniqueId(),
                Name = registration_dto.dto_Name,
                Email = registration_dto.dto_Email,
                Role = registration_dto.dto_Role,
                UserName = registration_dto.dto_UserName,
                phone = registration_dto.dto_phone,
                Password = UserAuth.EncryptSec(registration_dto.dto_Password),
                CreatedOn = DateTime.Now,
                CreatedBy = registration_dto.dto_CreatedBy,
                ModifiedOn = DateTime.Now,
                ModifiedBy = registration_dto.dto_ModifiedBy,

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
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return Ok(user);
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(Login_DTO login_DTO)
        {
            var user = await context.Users.FirstOrDefaultAsync(u=> u.Email == login_DTO.UserName || u.phone == login_DTO.UserName);
            //var user = await context.Users.FirstOrDefaultAsync(u=> u.Email == login_DTO.UserName);
            if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("User Not Found");
            }
            if (login_DTO == null || string.IsNullOrEmpty(login_DTO.UserName) || string.IsNullOrEmpty(login_DTO.Password) ){
                return BadRequest("Invalid Credentials.");
            }
            if(UserAuth.DecryptSec(user.Password)!= login_DTO.Password)
            {
                return BadRequest("Invalid Credentials.");
            }
            return Ok("Login Successfully");

        }
        [HttpPost("add-Role")]
        public Task<ActionResult> 




    }
}
