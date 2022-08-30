using eComerceWebsite.Data;
using eComerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;

namespace eComerceWebsite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsContext _context; // Must be read only.
        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products addedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(addedProduct); // Prepares insert

                _context.SaveChanges(); // Executes pending insert


                ViewData["Message"] = $"{addedProduct.ProductName} was added successfully!";
                return View();
            }

            return View(addedProduct);
        }
    }
}
