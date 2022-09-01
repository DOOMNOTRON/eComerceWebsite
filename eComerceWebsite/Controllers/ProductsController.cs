using eComerceWebsite.Data;
using eComerceWebsite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eComerceWebsite.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsContext _context; // Must be read only.
        public ProductsController(ProductsContext context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
            //method syntax
            // Get all products from the DB
            List<Products> products = await _context.Products.ToListAsync();

            // Query Syntax
            // List<Products> products = await (from product in _context.Products
            //                            select product).ToListAsync();

            // Show them on the web page
            return View(products);
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

        public async Task<IActionResult> Edit(int id) // must match the index
        {
            Products? productToEdit = await _context.Products.FindAsync(id);
            if(productToEdit == null)
            {
                return NotFound();
            }
            return View(productToEdit);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(Products productModel)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(productModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{productModel.ProductName} was successfully updated!";
                return RedirectToAction("Index");
            }
            return View(productModel);
        }
    }
}
 