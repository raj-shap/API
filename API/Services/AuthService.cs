using API.DTO.Auth;
using API.Helpers;
using API.Interfaces;
using API.Repositories;
using API.RequestModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.CodeAnalysis.Elfie.Model.Strings;

namespace API.Services
{
    public class AuthService
    {
        private readonly IAuth _auth;
        public AuthService(IAuth auth)
        {
            _auth = auth;
        }

        public async Task<Registration_DTO> AddUser(Registration_DTO registration)
        {
            if(registration == null)
            {
                throw new Exception("User Data is Required");
            }
            if(registration.dto_Password != registration.dto_ConfirmPassowrd)
            {
                throw new Exception("Password and Confirm Password must be same");
            }
            registration.dto_UserID = IdGenerator.GenerateUniqueId();
            var addedEmployee = await _auth.AddUser(registration);
            return addedEmployee;
        }

        public String Login(LoginRequest loginRequest)
        {
            if(loginRequest == null || string.IsNullOrEmpty(loginRequest.UserName) || string.IsNullOrEmpty(loginRequest.Password))
            {
                throw new Exception("Invalid Credentials");
            }
            var jwtToken = _auth.Login(loginRequest);
            return jwtToken;
        }
    }
}
