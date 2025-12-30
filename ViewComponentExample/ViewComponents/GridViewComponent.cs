using Microsoft.AspNetCore.Mvc;
using ViewComponentExample.Models;

namespace ViewComponentExample.ViewComponents
{
    public class GridViewComponent : ViewComponent //With this it will convert as viewcomponent
    {
        public async Task<IViewComponentResult> InvokeAsync( PersonGridModel gridsss)
        {

            //PersonGridModel personGridModel = new PersonGridModel()
            //{
            //    GridTitle = "Employee Details",
            //    Persons = new List<Person>
            //    {
            //        new Person
            //        {
            //            EmployeeName= "Vidyasagar",
            //            Job = "Devloper"
            //        },
            //        new Person
            //        {
            //            EmployeeName = "Sindhuja",
            //            Job = "Devloper"
            //        },
            //         new Person
            //        {
            //            EmployeeName = "Devamshika",
            //            Job = "Traineee"
            //        },

            //    }
            //};

           
           // ViewBag.GridDetails = model;

            return View("Default", gridsss);
            //This will be invoked views in the views  Views/Shared/Component/Grid/Default.cshtml  
            //Here in place of default can be any name we can replace
        }
    }
}

