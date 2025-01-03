using API.DTO.Auth;
using API.Models.Auth;
using API.RequestModels;

namespace API.Interfaces
{
    public interface IAuth
    {
        Task<Registration_DTO> AddUser(Registration_DTO registration_DTO);
        string Login(LoginRequest loginRequest);
<<<<<<< HEAD
        //Task<Token> GenerateNewTokenAsync(string userId);
        //Task<bool> ValidTokenAsync(string tokenValue);
=======
>>>>>>> 6beb24b5378205fffd940c8b3a9317f601c968ca
    }
}
