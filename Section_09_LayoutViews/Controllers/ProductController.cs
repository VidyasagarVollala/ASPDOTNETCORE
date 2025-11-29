using Microsoft.AspNetCore.Mvc;

namespace Section_09_LayoutViews.Controllers
{
    public class ProductController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("search-products/{ProductId?}")]
        public IActionResult SearchProduct(int? ProductId)
        {
            ViewBag.ProductId = ProductId;
            return View();
        }
        [Route("order-product")]
        public IActionResult OrderProduct()
        {
            return View();
        }

    }
}
