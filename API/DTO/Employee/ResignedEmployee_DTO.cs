using System.ComponentModel.DataAnnotations;

namespace API.DTO.Employee
{
    public class ResignedEmployee_DTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string EmpId { get; set; }
        [Required]
        public DateTime ResignedDate { get; set; }
        [Required]
        public string GivenInventories { get; set; }
        [Required]
        public string MissingInventory { get; set; }
        [Required]
        public string InventoryTakeStatus { get; set; }
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
