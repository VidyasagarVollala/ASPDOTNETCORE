using Microsoft.AspNetCore.Mvc;

namespace Section_13_Environments.Controllers
{
    public class HomeController : Controller
    {
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("/")]
        public IActionResult Index()
        {
          ViewBag.CurrentENVName =  _webHostEnvironment.EnvironmentName;
            return View();
        }
        //[Route("test")]
        //public IActionResult Index2()
        //{
        //    return View();
        //}

        //To open windows powershell in window search, search with Terminal
        //Changing of environment variables from the windows powershell is called  Process level environments
        //commands dotnet run
        //Without launch setting  dotnet run --no-launch-profile
        // setting up the Env from the the windows powershell$Env:ASPNETCORE_ENVIRONMENT="Staging"
    }
}
