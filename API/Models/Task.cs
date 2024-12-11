using API.Models.Auth;

namespace API.Models
{
    public class Task
    {
        public string Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public string SubTask { get; set; }
        public string AssignedBy { get; set; }
        public User UserId { get; set; }
        public DateTime AssignedDate { get; set; }
        public string Status { get; set; }
        public string Remark { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public String CreatedBy { get; set; }
        public User user { get; set; }
        public string ModifiedBy { get; set; }
        public User User { get; set; }
    } 
}
