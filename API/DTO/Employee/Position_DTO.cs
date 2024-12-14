using System.ComponentModel.DataAnnotations;

namespace API.DTO.Employee
{
    public class Position_DTO
    {
        [Required]
        public int dto_Id { get; set; }
        [Required]
        public string dto_PositionName{get; set;}
}
