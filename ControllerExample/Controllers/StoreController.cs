using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
	public class StoreController : Controller
	{
		[Route("store/books{id;int}")]
		public IActionResult Books()
		{
			int id = Convert.ToInt32(Request.RouteValues["id"]);
			return Content($"<h3>Book Store {id}</h3>","text/html");
		}
	}
}
