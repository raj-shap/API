namespace API.DTO.Inventory
{
    public class Accessories_DTO
    {
        public int dto_id { get; set; }
        public int dto_PurchaseId { get; set; }
        public string dto_SuplierId { get; set; }
        public string dto_Status { get; set; } // Availale | Assigned | Scrap
        public DateTime dto_CreatedOn { get; set; }
        public string dto_CreatedBy { get; set; }
        public DateTime dto_ModifiedOn { get; set; }
        public string dto_ModifiedBy { get; set; }
    }
}
