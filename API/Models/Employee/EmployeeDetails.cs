using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace API.Models.Employee
{
    public class EmployeeDetails
    {
        
        public string Id { get; set; }


        /////////////// :Personal Information: ///////////////

        
        public string UserName { get; set; }
        
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }
        
        public string LastName { get; set; }
        
        public string Email { get; set; }
        
        public string Dob { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }
        
        public string State { get; set; }
        
        public string Country { get; set; }
        
        public string PostalCode { get; set; }
        
        public string Phone { get; set; }
        
        public string EmergencyContactName { get; set; }
        
        public string EmergencyContact { get; set; }
        

        /////////////// :Position Information: ///////////////
        public int? DepartmentId { get; set; }
        public virtual Department? department { get; set; }
        
        public int? PositionId { get; set; } // Intern | Junior | Senior | Manager | HOD | BOD
        public virtual Position? position { get; set; }
        
        public string? ReportTo { get; set; }
        public virtual EmployeeDetails? employeeDetails { get; set; }
        
        public string EmployeementType { get; set; } // part time | full time | remote | hybrid

        /// <summary>
        /// ////////////////////
        /// </summary>
        
        public string Status { get; set; } // Active | Inactive(Resigned) | Deleted | onNoticePeriod
        
        public DateTime StartDate { get; set; }
        
        public DateTime CreatedOn { get; set; }
        
        public string CreatedBy { get; set; }
        
        public DateTime ModifiedOn { get; set; }
        
        public string ModifiedBy { get; set; }
    }
}
