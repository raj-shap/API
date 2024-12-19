using System.ComponentModel.DataAnnotations;

namespace API.DTO.Employee
{
    public class ResignedEmployee_DTO
    {
        [Required]
        public string dto_Id { get; set; }
        [Required]
        public string dto_EmpId { get; set; }
        [Required]
        public DateTime dto_ResignedDate { get; set; }
        [Required]
        public string dto_GivenInventories { get; set; }
        [Required]
        public string dto_MissingInventory { get; set; }
        [Required]
        public string dto_InventoryTakeStatus { get; set; }
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
