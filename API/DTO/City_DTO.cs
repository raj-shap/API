using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class City_DTO
    {
        [Required]
        public int Id { get; set; }
        public string CityName { get; set; }
        [Required]
        public int StateId { get; set; }
        public State_DTO State { get; set; }
    }
}
