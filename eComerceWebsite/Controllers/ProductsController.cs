using Microsoft.AspNetCore.Mvc;

namespace eComerceWebsite.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
