using eComerceWebsite.Data;
using Microsoft.AspNetCore.Mvc;
using eComerceWebsite.Models;
using Newtonsoft.Json;

namespace eComerceWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductsContext _context;
        private const string Cart = "ShoppingCart";

        public CartController(ProductsContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Products? productToAdd = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();

            if (productToAdd == null)
            {
                // Product with specified id does not exist
                TempData["Message"] = "Sorry, that product no longer exists.";
                return RedirectToAction("index", "Products");
            }

            CartProductViewModel cartProduct = new()
            {
                ProductID = productToAdd.ProductID,
                ProductName = productToAdd.ProductName,
                ProductPrice = productToAdd.ProductPrice,
            };

            List<CartProductViewModel> cartProducts = GetExistingCartData();
            cartProducts.Add(cartProduct);
            WriteShoppingCartCookie(cartProducts);

            TempData["Message"] = "Item added to cart!";
            return RedirectToAction("index", "Products");
        }

        private void WriteShoppingCartCookie(List<CartProductViewModel> cartProducts)
        {
            string cookieData = JsonConvert.SerializeObject(cartProducts);

            HttpContext.Response.Cookies.Append(Cart, cookieData, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddYears(1)
            });
        }

        /// <summary>
        /// Ruturn the current list of products in the users shopping
        /// car cookie. If there is no cookie, an empty list will be returned.
        /// </summary>
        /// <returns></returns>
        private List<CartProductViewModel> GetExistingCartData()
        {
            string? cookie = HttpContext.Request.Cookies[Cart];

            if (string.IsNullOrWhiteSpace(cookie))
            {
                return new List<CartProductViewModel>();
            }

            return JsonConvert.DeserializeObject<List<CartProductViewModel>>(cookie);
        }

        public  IActionResult Summary()
        {
            // Read shopping cart data and convert to list of view model
            List<CartProductViewModel> cartProducts = GetExistingCartData();
            return View(cartProducts);
        }

        public IActionResult Remove(int id)
        {
            List<CartProductViewModel> cartProducts = GetExistingCartData();

            CartProductViewModel targetProduct =
                cartProducts.Where(p => p.ProductID == id).FirstOrDefault();

            cartProducts.Remove(targetProduct);

            WriteShoppingCartCookie(cartProducts);

            return RedirectToAction(nameof(Summary));
        }

    }
}
