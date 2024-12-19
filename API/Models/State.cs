using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class State
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string StateName { get; set; }
        public ICollection<City> Cities { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
