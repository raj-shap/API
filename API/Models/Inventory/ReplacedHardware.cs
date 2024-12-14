using API.Models.Employee;

namespace API.Models.Inventory
{
    public class ReplacedHardware
    {
        public int Id { get; set; }
        public DateTime ReplacedDate { get; set; }
        public EmployeeDetails employee { get; set; }
        public string Hardware {  get; set; } 
        public string Remarark { get; set; }
        public int PurchaseId { get; set; }
        public PurchaseDetails purchase { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }

    }
}
