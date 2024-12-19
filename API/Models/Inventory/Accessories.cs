namespace API.Models.Inventory
{
    public class Accessories
    {
        public int id {  get; set; }
        public int PurchaseId {  get; set; }
        public string SuplierId { get; set; }
        public SupplierVendor supplierVendro { get; set; }
        public string Status { get; set; } // Availale | Assigned | Scrap
        public DateTime CreatedOn { get; set; }
        public string CreatedBy {get; set; }
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
    }
}
