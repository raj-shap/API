using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class User
    {
        [Required]
        public string UserID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Role { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string phone { get; set; }
        [Required]
        ////[StringLength(100, MinimumLength = 8, ErrorMessage ="Password must be at least 8 characters.")]
        ////[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,100}$",
        //    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,100}$",
        //    ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }
        //[Required]
        //[Compare("Password",ErrorMessage ="The Password and confirm Password do not match.")]
        //public string ConfirmPassowrd { get; set; }
        [Required]
        public string CreatedOn { get; set; }
        [Required]
        public string CreatedBy {  get; set; }
        [Required]
        public string ModifiedOn { get; set; }
        [Required]
        public string ModifiedBy { get; set; }
    }
}
