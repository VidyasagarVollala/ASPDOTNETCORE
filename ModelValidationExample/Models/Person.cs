using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationExample.Models
{
	public class Person
	{
		[Required(ErrorMessage = "{0} Can't be null or empty")]
		[Display(Name = "Person Name")] //{0} indicate the person name property for Name 
		[StringLength(30, MinimumLength = 3, ErrorMessage = "{0} should be in {1} and {2} character length")]
		public string? Name { get; set; }
		[ValidateNever]
		public string? Email { get; set; }
		[Phone(ErrorMessage ="{0} should be contain 10 digits only")]
		[BindNever]
		public string? Phone { get; set; }
		public List<string> Tags { get; set; } = new List<string>();

		public string? Password { get; set; }
		[Compare("Password",ErrorMessage = "Password and confirm password must be same")]
		public string? ConfirmPassword { get; set; }
		public override string ToString()
		{
			return $"Name {Name} Email {Email} Phone {Phone}  Password {Password} ConfirmPassword {ConfirmPassword}";
		}
	}
}
