namespace API.DTO
{
    public class State_DTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string StateName { get; set; }
        public ICollection<City_DTO> Cities { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country_DTO Country { get; set; }
    }
}
