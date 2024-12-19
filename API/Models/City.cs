using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class City
    {
        [Required]
        public int Id { get; set; }
        public string CityName { get; set; }
        [Required]
        public int StateId { get; set; }
        public State State { get; set; }
    }
}
