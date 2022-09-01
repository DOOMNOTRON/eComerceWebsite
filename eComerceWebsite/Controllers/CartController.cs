using eComerceWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using eComerceWebsite.Models;

namespace eComerceWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsContext _context;

        public CartController(ProductsContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Products? productToAdd = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();

            if(productToAdd == null)
            {
                // Product with specified id does not exist
                TempData["Message"] = "Sorry, that product no longer exists.";
                return RedirectToAction("index", "Products");
            }

            // 
            TempData["Message"] = "Item added to cart!";
            return RedirectToAction("index", "Products");
        }
    }
}
