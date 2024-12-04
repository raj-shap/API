namespace API.Models
{
    public class UserRoles
    {
        public string RoleId { get; set; }
        public Roles Roles { get; set; }
        public string UserId {  get; set; }
        public User User { get; set; }
    }
}
