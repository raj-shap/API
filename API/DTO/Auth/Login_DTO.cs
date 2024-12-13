using System.ComponentModel.DataAnnotations;

namespace API.DTO.Auth
{
    public class Login_DTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
