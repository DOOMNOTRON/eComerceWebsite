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
        public async Task<IActionResult> Create(Products addedProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(addedProduct); // Prepares insert

                // For async code info in the tutorial
                // https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-6.0
                await _context.SaveChangesAsync();  // Executes pending insert


                ViewData["Message"] = $"{addedProduct.ProductName} was added successfully!";
                return View();
            }

            return View(addedProduct);
        }
    }
}
