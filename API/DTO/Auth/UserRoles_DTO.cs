using System.ComponentModel.DataAnnotations;

namespace API.DTO.Auth
{
    public class UserRoles_DTO
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string UserName { get; set; }
    }
}
