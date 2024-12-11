namespace API.Models.Inventory
{
    public class AvailableLaptopAndDesktop
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public string ModelNumber { get; set; }
        public string Status { get; set; }
        public string RamSize { get; set; }
        public string RamType { get; set; }
        public string StorageSize { get; set; }
        public string StorageType { get; set; }
        public string Processor {  get; set; }
        public string OsActionvationKey { get; set; }
        public string OsActivatoinStatus { get; set; }
        public DateTime PurchaseDate {  get; set; }
        public string WarrentyStatus { get; set; } //in warrenty, out of warranty
        public string SupplierId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }

    }
}
