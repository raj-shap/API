using System.ComponentModel.DataAnnotations;

namespace API.DTO.Inventory
{
    public class LaptopAndDesktop_DTO
    {
        [Required]
        public int dto_Id { get; set; }
        [Required]
        public string dto_SerialNumber { get; set; }
        [Required]
        public string dto_ModelNumber { get; set; }
        [Required]
        public string dto_Status { get; set; } // Available | assigned | Scrap
        [Required]
        public string dto_RamSize { get; set; }
        [Required]
        public string dto_RamType { get; set; }
        [Required]
        public string dto_StorageSize { get; set; }
        [Required]
        public string dto_StorageType { get; set; }
        [Required]
        public string dto_Processor {  get; set; }
        [Required]
        public string dto_OsActionvationKey { get; set; }
        [Required]
        public string dto_OsActivatoinStatus { get; set; }
        [Required]
        public DateTime dto_PurchaseDate {  get; set; }
        [Required]
        public string dto_WarrentyStatus { get; set; } //in warrenty, out of warranty
        [Required]
        public string dto_SupplierId { get; set; }
        [Required]
        public DateTime dto_CreatedOn { get; set; }
        [Required]
        public DateTime dto_ModifiedOn { get; set; }
        [Required]
        public string dto_CreatedBy { get; set; }
        [Required]
        public string dto_ModifiedBy { get; set; }
    }
}
