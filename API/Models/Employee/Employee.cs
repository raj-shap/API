﻿using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Employee
{
    public class Employee
    {
        [Required]
        public string Id { get; set; }


        /////////////// :Personal Information: ///////////////

        [Required]
        public string UserName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string MiddleName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Dob { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string EmergencyContactName { get; set; }
        [Required]
        public string EmergencyContact { get; set; }
        [Required]
        public string Email { get; set; }

        /////////////// :Position Information: ///////////////
        [Required]
        public string Department { get; set; }
        [Required]
        public string Position { get; set; } // Intern | Junior | Senior | Manager | HOD | BOD 
        [Required]
        public string ReportTo { get; set; }
        [Required]
        public string EmployeementType { get; set; } // part time | full time | remote | hybrid
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime ModifiedOn { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
    }
}