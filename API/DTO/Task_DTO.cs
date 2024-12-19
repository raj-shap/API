using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class Task_DTO
    {
        [Required]
        public string dto_Id { get; set; }
        [Required]
        public string dto_TaskName { get; set; }
        [Required]
        public string dto_Description { get; set; }
        [Required]
        public string dto_SubTask { get; set; }
        [Required]
        public string dto_AssignedBy { get; set; }
        [Required]
        public string dto_AssignedTo { get; set; }
        [Required]
        public DateTime dto_AssignedDate { get; set; }
        [Required]
        public string dto_Status { get; set; }
        [Required]
        public string dto_Remark { get; set; }
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
