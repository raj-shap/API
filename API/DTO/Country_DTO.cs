
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class Country_DTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string CountryName { get; set; }
        
    }
}
