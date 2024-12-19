using System.ComponentModel.DataAnnotations;

namespace API.DTO.Auth
{
    public class Login_DTO
    {
        [Required]
        public string dto_UserName { get; set; }
        [Required]
        public string dto_Password { get; set; }
    }
}
