using eComerceWebsite.Data;
using eComerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace eComerceWebsite.Controllers
{
    public class MembersController : Controller
    {
        private readonly ProductsContext _context;

        public MembersController(ProductsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {

            if (ModelState.IsValid)
            {
                // Map RegisterViewModel data to member object
                Member newMember = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };

                _context.Members.Add(newMember);
                await _context.SaveChangesAsync();

                LogUserIn(newMember.Email);

                // Redirect to home page
                return RedirectToAction("Index", "Home");
            }
            return View(regModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                // Checks DB for credentials
                Member? m = (from member in _context.Members
                           where member.Email == loginModel.Email &&
                                 member.Password == loginModel.Password
                            select member).SingleOrDefault();
                // If Exists, send to homepage
                if (m != null)
                {
                    LogUserIn(loginModel.Email);
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(String.Empty, "Credentials not found!");
            }

            // Return page if no record found, or ModelState is invalid
            return View(loginModel);

        }

        private void LogUserIn(string email)
        {
            HttpContext.Session.SetString("Email", email);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
