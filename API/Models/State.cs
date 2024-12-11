namespace API.Models
{
    public class State
    {
        public int Id { get; set; }
        public string StateName { get; set; }
        public ICollection<City> Cities { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
