using System.ComponentModel.DataAnnotations;

namespace API.DTO.Auth
{
    public class Roles_DTO
    {
        [Required]
        public string dto_id { get; set; }
        [Required]
        public string dto_Name { get; set; }
    }
}
