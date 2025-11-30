using Microsoft.AspNetCore.Mvc;
using PartialViewsExamples.Models;

namespace PartialViewsExamples.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
          
            return View();
        }
        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("programing-languages")]
        public IActionResult ProgramingLanguages()
        {
            ListModel listModel = new ListModel();

            listModel.Title = "Cities";

            listModel.Tags = new List<string>
    {
    "Karimnagar",
    "Hyderabad",
    "Jagityal"
    };

            return PartialView("_ListPartialView", listModel);
        }
    }
}
