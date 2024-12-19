using API.Models.Employee;
using API.Models.Inventory;

namespace API.DTO.Inventory
{
    public class ReplacedHardware_DTO
    {
        public int dto_Id { get; set; }
        public DateTime dto_ReplacedDate { get; set; }
        public string dto_EmpId{ get; set; }
        public string dto_Hardware { get; set; }
        public string dto_Remarark { get; set; }
        public int dto_PurchaseId { get; set; }
        public DateTime dto_CreatedOn { get; set; }
        public string dto_CreatedBy { get; set; }
        public DateTime dto_ModifiedOn { get; set; }
        public string dto_ModifiedBy { get; set; }
    }
}
