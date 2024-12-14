using System.ComponentModel.DataAnnotations;

namespace API.DTO.Auth
{
    public class UserRoles_DTO
    {
        [Required]
        public string dto_RoleName { get; set; }
        [Required]
        public string dto_UserName { get; set; }
    }
}
