using Microsoft.AspNetCore.Mvc;
using Section_12_Services;
using ServiceContracts;

namespace Section_12_DI_Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesServices _citiesServices1;
        private readonly ICitiesServices _citiesServices2;
        private readonly ICitiesServices _citiesServices3;
        private readonly IServiceScopeFactory _scopeFactory;

        public HomeController(ICitiesServices citiesServices1, ICitiesServices citiesServices2, ICitiesServices citiesServices3, IServiceScopeFactory scopeFactory)
        {
            _citiesServices1 = citiesServices1;
            _citiesServices2 = citiesServices2;
            _citiesServices3 = citiesServices3;
            _scopeFactory = scopeFactory;
        }

        //Injecting the service into specific method only instead of constructor injecting.
        //[Route("/")]
        //public IActionResult Index([FromServices]ICitiesServices _citiesServices)
        //{
        //    IEnumerable<string> cities = _citiesServices.GetCities();
        //    return View(cities);
        //}

        [Route("/")]
        public IActionResult Index()
        {
            IEnumerable<string> cities = _citiesServices1.GetCities();
            ViewBag.Instance1 = _citiesServices1.InstanceId;
            ViewBag.Instance2 = _citiesServices2.InstanceId;
            ViewBag.Instance3 = _citiesServices3.InstanceId;

            //Tries to resolve the service
            //Throws an exception if the service is NOT registered
            //using IServiceScope scope = _scopeFactory.CreateScope();
            ////inject citiesService
            //ICitiesServices citiesServices = scope.ServiceProvider.GetRequiredService<ICitiesServices>(); //Throws an exception if the service is NOT registered
            //ViewBag.scope_InstanceID = citiesServices.InstanceId;


            //Tries to resolve the service
            //Returns null if the service is NOT registered
            //No exception
                //Another way

            using (IServiceScope scope = _scopeFactory.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var myService = serviceProvider.GetService<ICitiesServices>();  //Returns null if the service is NOT registered

            };


                return View(cities);
        }
    }
}
