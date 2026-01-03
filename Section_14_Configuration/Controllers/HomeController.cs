using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;

namespace Section_14_Configuration.Controllers
{
    public class HomeController : Controller
    {
        private readonly WeatherApiOption _options;



        public HomeController(IOptions<WeatherApiOption> options)
        {
           _options = options.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            //Reading normal json object value from appsetting.json
            //ViewBag.MyKey = _configuration["MyKey"];
            //ViewBag.MyAPIKey = _configuration.GetValue("MyAPI", "Defaulkt API key");


            ////Reading hirachical(inside object another value) json object value from appsetting.json
            //ViewBag.ClientSecret = _configuration["WeatherAPI:ClientSecret"];
            //ViewBag.ClientAPI = _configuration.GetValue("WeatherAPI:ClientAPI", "Defaulkt API key");


            ////Reading hirachical(inside object another value) json object value from appsetting.json another way
            //IConfigurationSection weatherAPI = _configuration.GetSection("WeatherAPI");

            //ViewBag.ClientSecret = weatherAPI["ClientSecret"];
            //ViewBag.ClientAPI = weatherAPI["ClientAPI"];


            ////Reading hirachical(inside object another value) json object value from appsetting.json option pattern
            //WeatherApiOption options = _configuration.GetSection("WeatherAPI").Get<WeatherApiOption>();


            ViewBag.ClientSecret = _options.ClientSecret;
            ViewBag.ClientAPI = _options.ClientAPI;

         /*   What is IOptions<T> ?

IOptions<T> is an interface provided by Microsoft.Extensions.Options that:

Reads configuration values

Binds them to a strongly-typed class

Injects them using Dependency Injection(DI)

Instead of doing this ❌:

var issuer = Configuration["Jwt:Issuer"];


    You do this ✅:

IOptions<JwtOptions>*/

            return View();


        }
    }



    /*
     priority of reading the configuration values
        Environment Specific configuration.
   5  appsetting.json
                                      appsetting.Devlopment.json
    4 appsetting.Devlopment.json       appsetting.Staging.json
                                      appsetting.Production.json
   3  UserSecrets(secretManger) --- It will works only in the development only and it will store in the developer local machine only it will not pushed to any code repository like git
  2  Environment Variables
   1 Command Line Arguments
             */

}
