using System.ComponentModel.DataAnnotations;

namespace API.DTO.Employee
{
    public class Employee_DTO
    {
        [Required]
        public string dto_Id { get; set; }


        /////////////// :Personal Information: ///////////////

        [Required]
        public string dto_UserName { get; set; }
        [Required]
        public string dto_FirstName { get; set; }
        [Required]
        public string dto_MiddleName { get; set; }
        [Required]
        public string dto_LastName { get; set; }
        [Required]
        public string dto_Email { get; set; }
        [Required]
        public string dto_Dob { get; set; }
        [Required]
        public string dto_Address { get; set; }
        [Required]
        public string dto_City { get; set; }
        [Required]
        public string dto_State { get; set; }
        [Required]
        public string dto_Country { get; set; }
        [Required]
        public string dto_PostalCode { get; set; }
        [Required]
        public string dto_Phone { get; set; }
        [Required]
        public string dto_EmergencyContactName { get; set; }
        [Required]
        public string dto_EmergencyContact { get; set; }

        /////////////// :Position Information: ///////////////
        [Required]
        public int dto_Department { get; set; }
        [Required]
        public int dto_Position { get; set; } // Intern | Junior | Senior | Manager | HOD | BOD 
        [Required]
        public string dto_ReportTo { get; set; }
        [Required]
        public string dto_EmployeementType { get; set; } // part time | full time | remote | hybrid
        /// <summary>
        /// ////////////////////
        /// </summary>
        [Required]
        public string dto_Status { get; set; } // Active | Inactive(Resigned) | Deleted | onNoticePeriod
        [Required]
        public DateTime dto_StartDate { get; set; }
        [Required]
        public DateTime dto_CreatedOn { get; set; }
        [Required]
        public string dto_CreatedBy { get; set; }
        [Required]
        public DateTime dto_ModifiedOn { get; set; }
        [Required]
        public string dto_ModifiedBy { get; set; }
    }
}
