using System.ComponentModel.DataAnnotations;

namespace API.Models.Employee
{
    public class Position
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string PositionName { get; set; }
        public virtual ICollection<EmployeeDetails> Details { get; set; }
    }
}
