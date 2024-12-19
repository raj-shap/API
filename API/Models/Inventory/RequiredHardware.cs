using API.Models.Employee;

namespace API.Models.Inventory
{
    public class RequiredHardware
    {
        public int Id { get; set; }
        public string HardwareName { get; set; }
        public int Quantity { get; set; }
        public string? EmpId { get; set; }
        public EmployeeDetails EmployeeDetails { get; set; }
        public DateTime DateOfRequirement { get; set; }
        public string Remarks { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy {  get; set; }
    }
}
