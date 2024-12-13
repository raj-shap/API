using System.ComponentModel.DataAnnotations;

namespace API.DTO.Auth
{
    public class Roles_DTO
    {
        [Required]
        public string id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
