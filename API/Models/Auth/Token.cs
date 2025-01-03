namespace API.Models.Auth
{
    public class Token
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        public string Value { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsActive { get; set; }
    }
}
