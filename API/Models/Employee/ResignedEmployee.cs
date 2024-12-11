namespace API.Models.Employee
{
    public class ResignedEmployee
    {
        public string Id { get; set; }
        public string EmpId { get; set; }
        public Employee Employee { get; set; }
        public DateTime ResignedDate { get; set; }
        public string GivenInventories { get; set; }
        public string MissingInventory { get; set; }
        public string InventoryTakeStatus { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
