using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class City_DTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CityName { get; set; }
        [Required]
        public int StateId { get; set; }
    }
}
