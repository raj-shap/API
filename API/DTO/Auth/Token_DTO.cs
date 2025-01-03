namespace API.DTO.Auth
{
    public class Token_DTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Value { get; set; }
        public DateTime Expiration { get; set; }
        public bool IsActive { get; set; }
    }
}
