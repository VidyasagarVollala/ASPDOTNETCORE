using Microsoft.AspNetCore.Mvc;
using Section_8_RazorViewsExample.Model;

namespace Section_8_RazorViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("home")]
        [Route("/")]
        public IActionResult Index()
        {

            List<Person> people = new List<Person>
    {
    new Person()
    {
        Name="Vidyasagar", Age=29,Gender=Gender.Male, SurName="Vollala"
    }, new Person()
    {
        Name="Sindhuja", Age=25,Gender=Gender.Female, SurName="Vollala"
    }, new Person()
    {
        Name="Devamshika", Age=1,Gender=Gender.Female, SurName="Vollala"
    }

    };
            ViewData["appTtitle"] = "Welcome to dotnet core view";


            // ViewData["person"] = people;

            // ViewBag.people = people;

            //strongly typed view example
            return View("Index", people);
        }
        //[Route("person-product")]

        //public IActionResult PersonWithProduct()
        //{
        //    Person people = new Person() { Name = "Vidyasagar", Age = 29, Gender = Gender.Male, SurName = "Vollala" };


        // Product product = new Product()
        // {
        //     Id = 1, Description = "Mobile"
        // };
           
        //    PersonDataWithProduct personDataWithProduct = new PersonDataWithProduct() { PersonData = people, ProductData = product };
        //    return View("PersonWithProduct",personDataWithProduct);
        //}


        [Route("person-product2")]

        public IActionResult PersonWithProduct2()
        {
            List<Person> people  = new List<Person>
            {
    new Person()
    {
        Name="Vidyasagar", Age=29,Gender=Gender.Male, SurName="Vollala"
    }, new Person()
    {
        Name="Sindhuja", Age=25,Gender=Gender.Female, SurName="Vollala"
    }, new Person()
    {
        Name="Devamshika", Age=1,Gender=Gender.Female, SurName="Vollala"
    }

    };


            List<Product> products = new List<Product>()
           {
               new Product ()
               {
                   Id=1, Description="Mobile"
               }, new Product()
               {
                   Id=1, Description="Laptop"
               }
           };

            PersonDataWithProduct personDataWithProduct = new PersonDataWithProduct() { PersonData = people , ProductData = products };
            return View("PersonWithProduct", personDataWithProduct);
        }
    }
}
