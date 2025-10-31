using Microsoft.AspNetCore.Mvc;

namespace ControllerExample.Controllers
{
	public class HomeController 
	{
		[Route("index")]
		[Route("/")] //Indicates Default route
		public string Index()
		{
			return "Hello Sindhu_Devamshika from Index ";
		}

		[Route("about")]
		public string About()
		{
			return "Hello Sindhu_Devamshika from About ";
		}

		[Route("contact-us")]
		public string Contact()
		{
			return "Hello Sindhu_Devamshika from Contact ";
		}

		[Route("byEmpId/{id:int}")] //Routing constrains like int, bool
		public string Employee()
		{
			return "Hello Sindhu_Devamshika from Employee ";
		}


	}
}
