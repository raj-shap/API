using System.ComponentModel.DataAnnotations;

namespace API.Models.Auth
{
    public class Role
    {
        [Key]
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
