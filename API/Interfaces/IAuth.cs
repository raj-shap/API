using API.DTO.Auth;
using API.Models.Auth;
using API.RequestModels;

namespace API.Interfaces
{
    public interface IAuth
    {
        Task<Registration_DTO> AddUser(Registration_DTO registration_DTO);
        string Login(LoginRequest loginRequest);
    }
}
