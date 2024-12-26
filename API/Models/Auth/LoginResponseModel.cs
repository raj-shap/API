namespace API.Models.Auth
{
    public class LoginResponseModel
    {
        public string? UserName { get; set; }
        public string? AccessToken { get; set; }
        public string? ExpiresIn { get; set; }
    }
}
