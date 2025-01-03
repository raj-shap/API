using System.ComponentModel.DataAnnotations;

namespace API.Models.Auth
{
    public class UserRoles
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string RoleId { get; set; }
        [Required]
        public Role Role { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public User User { get; set; }
    }
}
