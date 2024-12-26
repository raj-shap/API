using System.ComponentModel.DataAnnotations;

namespace API.Models.Employee
{
    public class Department
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public virtual ICollection<EmployeeDetails> EmployeeDetails { get; set; }
    }
}
