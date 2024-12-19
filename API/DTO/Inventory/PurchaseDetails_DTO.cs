using API.Models.Employee;
using API.Models;

namespace API.DTO.Inventory
{
    public class PurchaseDetails_DTO
    {
        public int dto_Id { get; set; }
        public string dto_EmpId { get; set; }
        public string dto_ProductName { get; set; }
        public string dto_Model { get; set; }
        public string dto_SerialNumber { get; set; }
        public int dto_Qunatity { get; set; }
        public string dto_VendorId { get; set; }
        public DateTime dto_PurchaseDate { get; set; }
        public double dto_Warrenty { get; set; }
        public double dto_Price { get; set; }
        public string dto_CreatedBy { get; set; }
        public DateTime dto_CreatedOn { get; set; }
        public string dto_ModifiedBy { get; set; }
        public DateTime dto_ModifiedOn { get; set; }
    }
}
