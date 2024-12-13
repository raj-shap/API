using System.ComponentModel.DataAnnotations;

namespace API.DTO.Employee
{
    public class Position_DTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PositionName{get; set;}
}
