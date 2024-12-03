using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
	public class Registration_DTO
	{
		[Required]
		public string dto_UserID { get; set; }
		[Required]
		public string dto_Name { get; set; }
		[Required]
		public string dto_Email { get; set; }
		[Required]
		public string dto_Role { get; set; }
		[Required]
		public string dto_UserName { get; set; }
		[Required]
		public string dto_phone { get; set; }
		[Required]
		public string dto_Password { get; set; }
		[Required]
		public string dto_ConfirmPassowrd { get; set; }
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
