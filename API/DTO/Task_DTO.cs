﻿using API.Models.Auth;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class Task_DTO
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
        public string Status { get; set; }
        [Required]
        public string Remark { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required]
        public String CreatedBy { get; set; }
        public User user { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
        [Required]
        public User User { get; set; }
    }
}