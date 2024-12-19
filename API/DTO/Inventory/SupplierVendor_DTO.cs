namespace API.DTO.Inventory
{
    public class SupplierVendor_DTO
    {
        public string dto_Id { get; set; }
        public string dto_Name { get; set; }
        public string dto_Email { get; set; }
        public string dto_Phone { get; set; }
        public string dto_Type { get; set; } //supplier or vendor
        public string dto_CreatedOn { get; set; }
        public string dto_CreatedBy { get; set; }
        public string dto_ModifiedOn { get; set; }
        public string dto_ModifiedBy { get; set; }
    }
}
