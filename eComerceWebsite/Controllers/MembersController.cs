using Microsoft.AspNetCore.Mvc;

namespace eComerceWebsite.Controllers
{
    public class MembersController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
