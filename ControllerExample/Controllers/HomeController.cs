using ControllerExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
	public class HomeController :Controller
	{
		//[Route("index")]
		//[Route("/")] //Indicates Default route
		//public string Index()
		//{
		//	return "Hello Sindhu_Devamshika from Index ";
		//}

		//[Route("about")]
		//public string About()
		//{
		//	return "Hello Sindhu_Devamshika from About ";
		//}

		//[Route("contact-us")]
		//public string Contact()
		//{
		//	return "Hello Sindhu_Devamshika from Contact ";
		//}

		//[Route("byEmpId/{id:int}")] //Routing constrains like int, bool
		//public string Employee()
		//{
		//	return "Hello Sindhu_Devamshika from Employee ";
		//}

		////Content result example
		//[Route("index")]
		//[Route("/")] //Indicates Default route
		//public ContentResult Index()
		//{
		//	//return new ContentResult() { Content = "index" ,ContentType="text/plain"};//here conent will be response header and contentType is contenetType in broweser
		//	//return Content("<h1>Hello from Index</h2>", "text/html");//This is the shortest form for above this all return types will be available in Contoller parent class
		//	return Content("{\"Name\":\"sagar\",\"age\":\"29\"}", "application/json");
		//}


		//Json result example
		[Route("person")]
		public JsonResult Person()
		{
			//Instead of writing manually there is other method available as new JsonResult()
			//return Content("{\"Name\":\"sagar\",\"age\":\"29\"}", "application/json");

			Person person = new Person() { Id = Guid.NewGuid(), Name = "Vidyasagar", FatherName = "Laxman", Age = 29 };
			//return new JsonResult(person); below is simple and real world using example
			return Json(person);
		}

		//File result example
		//Used when file in wwwroot
		[Route("file-download")]
		public VirtualFileResult Download()
		{
			
			return new VirtualFileResult("/ssc.pdf","application/pdf");
		}
		//Used when file in outside wwwroot folder
		[Route("file-download2")]
		public PhysicalFileResult Download2()
		{

			return new PhysicalFileResult(@"d:\ssc.pdf", "application/pdf");
		}

		//Used when file response from other sources
		[Route("file-download3")]
		public FileContentResult Download3()
		{

			byte[] bytes = System.IO.File.ReadAllBytes(@"d:\ssc.pdf");
			return new FileContentResult(bytes, "application/pdf");
		}
		//IActionResult is parent class of all returntypes 
		//public IActionResult Index()
		//{
		//	//return NotFound("");
		//	//return Unauthorized();
		//	return StatusCode(300);


		//}
		//RedirectionResult example
		[Route("bookstore")]
		public IActionResult Index()
		{
			//return new RedirectToActionResult("Books", "Store", new { });////302 -found
			//return RedirectToAction("Books", "Store", new { id=123});


			//return new RedirectToActionResult("Books", "Store", new { });////301 -moved permanently
			//return RedirectToActionPermanent("Books", "Store", new {id=12 });

			//	return LocalRedirectResult($"/store/books{id}");
			//return LocalRedirectPermanent($"/store/books{1}");

			//return Redirect($"/store/books{1}");
			return RedirectPermanent($"/store/books{1}");

		}


	}
}
