using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class State_DTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string StateName { get; set; }
        [Required]
        public int CountryId { get; set; }
    }
}
