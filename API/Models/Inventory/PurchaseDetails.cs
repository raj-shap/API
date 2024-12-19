
using API.Models.Employee;

namespace API.Models.Inventory
{
    public class PurchaseDetails
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public EmployeeDetails employee { get; set; }
        public string ProductName { get; set; }
        public string Model { get; set; }
        public string SerialNumber { get; set; }
        public int Qunatity { get; set; }
        public string VendorId { get; set; }
        public SupplierVendor SupplierVendor { get; set; }
        public DateTime PurchaseDate {  get; set; }
        public double Warrenty {  get; set; }
        public double Price { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn {  get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
