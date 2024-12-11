﻿namespace API.Models.Auth
{
    public class UserRoles
    {
        public int Id { get; set; }
        public string RoleId { get; set; }
        public Role Role { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
