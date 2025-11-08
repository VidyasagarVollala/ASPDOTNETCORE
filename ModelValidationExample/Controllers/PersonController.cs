using Microsoft.AspNetCore.Mvc;
using ModelValidationExample.CustomeModelBinderClass;
using ModelValidationExample.Models;

namespace ModelValidationExample.Controllers
{
	public class PersonController : Controller
	{
		//[Route("person")]
		//	public IActionResult Index([Bind(nameof(Person.Name),nameof(Person.Email)]Person? person) // here nameof(Person.Name) is indicates "Name" of person class if any chages happened to that property here also same will apply
		//Use of the bind is when unknow passed more than person class property it will ignore
		//instead of including here we can mention what are property need to be ignore in property level also by BindNever
		//public IActionResult Index(Person? person, [FromHeader(Name ="User-agent")]string userAgent, [FromHeader(Name = "Auth-Key")] string authkey)
		//{

		//	//if(!ModelState.IsValid)
		//	//{
		//	//	string errors = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()) ;

		//	//	return BadRequest(errors);
		//	//}
		//	return Content($"{person} {userAgent}");
		//}
		[Route("person")]
		public IActionResult Index([FromBody]Person? person)
		{

			//if(!ModelState.IsValid)
			//{
			//	string errors = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()) ;

			//	return BadRequest(errors);
			//}
			return Content($"{person} ");
		}
	}
}
