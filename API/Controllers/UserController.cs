using API.Models;
using Microsoft.AspNetCore.Mvc;
using API.Helpers;
using Microsoft.EntityFrameworkCore;
using API.Models.Auth;
using API.DTO.Auth;
using API.Services;
using API.RequestModels;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext context;
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;
        public UserController(MyDbContext context, IConfiguration configuration, AuthService authService)
        {
            this.context = context;
            _configuration = configuration;
            _authService = authService;
        }
        [HttpPost("Registration")]
        public async Task<ActionResult<User>> CreateUser(Registration_DTO registration_dto)
        {
            if (registration_dto == null)
            {
                return BadRequest("Please Enter a valid details");
            }
            try
            {
                var user = await _authService.AddUser(registration_dto);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error : ${ex.Message}");
            }
            {
                //var response = new Registration_DTO();
                //if (registration_dto == null)
                //{
                //    response.Errors.Add("User Data is required");
                //    return BadRequest(response);
                //}
                //bool userExist = await context.Users.AnyAsync(u => u.Email == registration_dto.dto_Email || u.phone == registration_dto.dto_phone);

                //if (userExist)
                //{
                //    response.Errors.Add("A user is already registered with email or phone");
                //    //return BadRequest("A user is already registered with email or phone");
                //}

                //if (registration_dto.dto_Password != registration_dto.dto_ConfirmPassowrd)
                //{
                //    response.Errors.Add("Password and Confirm Password must be same.");
                //    //return BadRequest("Password and Confirm Password must be same.");
                //}
                //if (response.Errors.Count > 0)
                //{
                //    return BadRequest(response);
                //}

                //registration_dto.dto_UserID = IdGenerator.GenerateUniqueId();
                //var user = new User()
                //{
                //    UserID = registration_dto.dto_UserID,
                //    Name = registration_dto.dto_Name,
                //    Email = registration_dto.dto_Email,
                //    Role = registration_dto.dto_Role,
                //    UserName = registration_dto.dto_UserName,
                //    phone = registration_dto.dto_phone,
                //    Password = UserAuth.EncryptSec(registration_dto.dto_Password),
                //    Status = registration_dto.dto_Status,
                //    //CreatedOn = registration_dto.dto_CreatedOn,
                //    CreatedOn = DateTime.Now,
                //    CreatedBy = registration_dto.dto_CreatedBy,
                //    //ModifiedOn = registration_dto.dto_ModifiedOn,
                //    ModifiedOn = DateTime.Now,
                //    ModifiedBy = registration_dto.dto_ModifiedBy,

                //};
                ////user.CreatedOn = DateTime.Now;
                ////user.ModifiedOn = DateTime.Now;

                //////if(user.Password != user.ConfirmPassowrd)
                //////{
                //////    return BadRequest("Password and Confirm passoword must be same.");
                //////}
                ////string encryptedPassword = UserAuth.EncryptSec(user.Password);
                //////string encryptedConfirmPassword = UserAuth.EncryptSec(user.ConfirmPassowrd);
                ////user.Password = encryptedPassword;
                //////user.ConfirmPassowrd = encryptedConfirmPassword;
                ////user.UserID = IdGenerator.GenerateUniqueId();
                //////Generate a unique ID for the user
                //await context.Users.AddAsync(user);
                //await context.SaveChangesAsync();
                //return Ok(user);
            }
        }
        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequest loginRequest)
        {
            if(loginRequest == null)
            {
                return BadRequest("Please enter valid Credentials");
            }
            try
            {
                var jwtToken = _authService.Login(loginRequest);
                return Ok(jwtToken);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Internal server error : {ex.Message}");
            }

            {
                //if (login_DTO == null || string.IsNullOrEmpty(login_DTO.dto_UserName) || string.IsNullOrEmpty(login_DTO.dto_Password) ){
                //    return BadRequest("Invalid Credentials.");
                //}

                //var user = await context.Users.FirstOrDefaultAsync(u=> u.Email == login_DTO.dto_UserName || u.phone == login_DTO.dto_UserName);
                ////var user = await context.Users.FirstOrDefaultAsync(u=> u.Email == login_DTO.UserName);

                //if (user == null || string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                //{
                //    return BadRequest("User Not Found");
                //}
                //if(UserAuth.DecryptSec(user.Password)!= login_DTO.dto_Password)
                //{
                //    return BadRequest("Invalid Credentials.");
                //}
                //var getUserId = (await context.Users.FirstOrDefaultAsync(u => u.Email == login_DTO.dto_UserName || u.phone == login_DTO.dto_UserName)).UserID;
                //var getRoleId = (await context.UserRoles.FirstOrDefaultAsync(r => r.UserId == getUserId)).RoleId;
                //var roleName = (await context.Role.FirstOrDefaultAsync(r => r.id == getRoleId)).Name;
                //var claims = new List<Claim>
                //{
                //    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                //    new Claim("Id",user.UserID),
                //    new Claim("UserName",user.UserName),
                //};
                //var userRoles = context.UserRoles.Where(u=> u.UserId == user.UserID).ToList();
                //var roleIds = userRoles.Select(s=>s.RoleId).ToList();
                //var roles = context.Role.Where(r=>roleIds.Contains(r.id)).ToList();
                //foreach(var role in roles)
                //{
                //    claims.Add(new Claim(ClaimTypes.Role,role.Name));
                //}
                //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                //var signIn = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
                //var token = new JwtSecurityToken(
                //        _configuration["Jwt:Issuer"],
                //        _configuration["Jwt:Audience"],
                //        claims,
                //        expires:DateTime.UtcNow.AddMinutes(10),
                //        signingCredentials:signIn
                //    );
                //var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                //return Ok(jwtToken);

                //return Ok("Login Successfully");
            }
        }
        [HttpPost("add-Role")]
        public async Task<ActionResult> AddRole([FromBody]Roles_DTO roles_DTO)
        {
            if(roles_DTO == null)
            {
                BadRequest("Role Name is Required.");
            }
            bool RoleExist = await context.Role.AnyAsync(r=> r.Name == roles_DTO.dto_Name);
            if (RoleExist)
            {
                BadRequest("Role Already Created");
            }
            roles_DTO.dto_id = IdGenerator.GenerateUniqueId();
            var roles = new Role()
            {
                Id = roles_DTO.dto_id,
                Name = roles_DTO.dto_Name
            }; 
            await context.Role.AddAsync(roles);
            await context.SaveChangesAsync();
            return Ok(roles);
        }

        [HttpPost("assign-role")]
        public async Task<ActionResult> AssignRole([FromBody]UserRoles_DTO userRoles_DTO)
        {
            if(userRoles_DTO.dto_UserName == null)
            {
                return BadRequest("UserId required");
            }
            if(userRoles_DTO.dto_RoleName == null)
            {
                return BadRequest("RoleId required");
            }
            bool UserExist = await context.Users.AnyAsync(u => u.Email == userRoles_DTO.dto_UserName);
            bool RoleExist = await context.Role.AnyAsync(r=> r.Name == userRoles_DTO.dto_RoleName);
            if (!UserExist)
            {
                return NotFound("User not Exist");
            }
            if(!RoleExist)
            {
                return NotFound("Role not Exist");
            }
            var uid = (await context.Users.FirstOrDefaultAsync(u => u.Email == userRoles_DTO.dto_UserName)).UserID;
            var roleId = (await context.Role.FirstOrDefaultAsync(r => r.Name == userRoles_DTO.dto_RoleName)).Id;
            var userRoles = new UserRoles()
            {
                UserId = uid,
                RoleId = roleId
            };
            await context.UserRoles.AddAsync(userRoles);
            await context.SaveChangesAsync();
            return Ok(userRoles);
        }

    }
}
