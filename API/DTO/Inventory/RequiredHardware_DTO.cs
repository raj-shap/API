using API.Models.Employee;

namespace API.DTO.Inventory
{
    public class RequiredHardware_DTO
    {
        public int dto_Id { get; set; }
        public string dto_HardwareName { get; set; }
        public int dto_Quantity { get; set; }
        public string dto_EmpId { get; set; }
        public DateTime dto_DateOfRequirement { get; set; }
        public string dto_Remarks { get; set; }
        public DateTime dto_CreatedOn { get; set; }
        public string dto_CreatedBy { get; set; }
        public DateTime dto_ModifiedOn { get; set; }
        public string dto_ModifiedBy { get; set; }
    }
}
