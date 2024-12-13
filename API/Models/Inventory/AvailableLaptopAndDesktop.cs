using System.ComponentModel.DataAnnotations;

namespace API.Models.Inventory
{
    public class AvailableLaptopAndDesktop
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string ModelNumber { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string RamSize { get; set; }
        [Required]
        public string RamType { get; set; }
        [Required]
        public string StorageSize { get; set; }
        [Required]
        public string StorageType { get; set; }
        [Required]
        public string Processor {  get; set; }
        [Required]
        public string OsActionvationKey { get; set; }
        [Required]
        public string OsActivatoinStatus { get; set; }
        [Required]
        public DateTime PurchaseDate {  get; set; }
        [Required]
        public string WarrentyStatus { get; set; } //in warrenty, out of warranty
        [Required]
        public string SupplierId { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public string ModifiedBy { get; set; }

    }
}
