﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using API.DTO.Auth;
using API.Helpers;
using API.Interfaces;
using API.Models;
using API.Models.Auth;
using API.RequestModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace API.Repositories
{
    public class AuthRepository : IAuth
    {
        private readonly MyDbContext _myDbContext;
        private readonly IConfiguration _configuration;
        public AuthRepository(MyDbContext myDbContext, IConfiguration configuration)
        {
            _myDbContext = myDbContext;
            _configuration = configuration;
        }
        public async Task<Registration_DTO> AddUser(Registration_DTO registration_dto)
        {
            bool userExist = await _myDbContext.Users.AnyAsync(u => u.Email == registration_dto.dto_Email);
            if (userExist)
            {
                throw new Exception("User Already Registered.");
            }
            try
            {
                var addUser = new User()
                {
                    UserID = registration_dto.dto_UserID,
                    Name = registration_dto.dto_Name,
                    Email = registration_dto.dto_Email,
                    Role = registration_dto.dto_Role,
                    UserName = registration_dto.dto_UserName,
                    phone = registration_dto.dto_phone,
                    Password = UserAuth.EncryptSec(registration_dto.dto_Password),
                    Status = registration_dto.dto_Status,
                    //CreatedOn = registration_dto.dto_CreatedOn,
                    CreatedOn = DateTime.Now,
                    CreatedBy = registration_dto.dto_CreatedBy,
                    //ModifiedOn = registration_dto.dto_ModifiedOn,
                    ModifiedOn = DateTime.Now,
                    ModifiedBy = registration_dto.dto_ModifiedBy,
                };

                var addedUser = new Registration_DTO
                {
                    dto_UserID = addUser.UserID,
                    dto_Name = addUser.Name,
                    dto_Email = addUser.Email,
                    dto_Role = addUser.Role,
                    dto_UserName = addUser.UserName,
                    dto_phone = addUser.phone,
                    dto_Password = addUser.Password,
                    dto_Status = addUser.Status,
                    dto_CreatedBy = addUser.CreatedBy,
                    dto_CreatedOn = addUser.CreatedOn,
                    dto_ModifiedBy = addUser.ModifiedBy,
                    dto_ModifiedOn = addUser.ModifiedOn,

                };

                await _myDbContext.Users.AddAsync(addUser);
                await _myDbContext.SaveChangesAsync();

                return addedUser;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw new Exception($"Error while Registering new user : {ex.Message}");
            }
        }

<<<<<<< HEAD

=======
>>>>>>> 6beb24b5378205fffd940c8b3a9317f601c968ca
        public string Login(LoginRequest loginRequest)
        {
            var user = _myDbContext.Users.SingleOrDefault(s => s.Email == loginRequest.UserName);

            if (user != null)
            {
                if (UserAuth.DecryptSec(user.Password) != loginRequest.Password)
                {
                    throw new Exception("Please Enter a valid Credential");
                }
<<<<<<< HEAD

                var jwtToken = JWT.GenerateJwtToken(user.UserID,user.Name,user.Email, _configuration);
                //var claims = new[]
                //{
                //    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                //    new Claim("Id",user.UserID),
                //    new Claim("UserName",user.Name),
                //    new Claim("Email",user.Email),
                //    new Claim(JwtRegisteredClaimNames.Jti, IdGenerator.GenerateUniqueId())
                //};

                //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                ////var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
                //var token = new JwtSecurityToken(
                //    _configuration["Jwt:Issuer"],
                //    _configuration["Jwt:Audience"],
                //    claims,
                //    expires: DateTime.UtcNow.AddMinutes(100),
                //    signingCredentials: signIn);
                //var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
=======
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim("Id",user.UserID),
                    new Claim("UserName",user.Name),
                    new Claim("Email",user.Email),
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                //var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
                var token = new JwtSecurityToken(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.UtcNow.AddMinutes(10),
                    signingCredentials: signIn);

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
>>>>>>> 6beb24b5378205fffd940c8b3a9317f601c968ca
                return jwtToken;
            }
            else
            {
                throw new Exception("User Not Found");
            }
        }
<<<<<<< HEAD
        
        //public async Task<Token> GenerateNewTokenAsync(string userId)
        //{
        //    var oldTokens = _myDbContext.Tokens.Where(t => t.UserId == userId && t.IsActive);
        //    foreach (var token in oldTokens)
        //    {
        //        token.IsActive = false;
        //    }
        //    var newToken = new Token
        //    {
        //        Value = ,
        //        Expiration = DateTime.UtcNow.AddMinutes(10),
        //        IsActive = true,
        //        UserId = userId,
        //    };
        //    _myDbContext.Tokens.Add(newToken);
        //    await _myDbContext.SaveChangesAsync();

        //    return newToken;
        //}
        public async Task<bool> ValidTokenAsync(string tokenValue)
        {
            var token = await _myDbContext.Tokens.FirstOrDefaultAsync(t => t.Value == tokenValue);
            if(token == null || !token.IsActive || token.Expiration < DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }
=======
>>>>>>> 6beb24b5378205fffd940c8b3a9317f601c968ca
    }
}
