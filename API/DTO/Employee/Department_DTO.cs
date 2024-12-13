using System.ComponentModel.DataAnnotations;

namespace API.DTO.Employee
{
    public class Department_DTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
