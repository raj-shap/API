using API.DTO.Auth;

namespace API.Repository
{
    public interface IAuthService
    {
        Task<AuthResponse_DTO> Register(Registration_DTO registration_DTO);
        Task<AuthResponse_DTO> Login(Login_DTO login_DTO);
    }
}
