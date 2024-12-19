using API.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Task
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string SubTask { get; set; }
        [Required]
        public string AssignedBy { get; set; }
        [Required]
        public User UserId { get; set; }
        [Required]
        public DateTime AssignedDate { get; set; }
        [Required]
        public string Status { get; set; } //Done | Pending | Running
        [Required]
        public string Remark { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required]
        public String CreatedBy { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
    } 
}
