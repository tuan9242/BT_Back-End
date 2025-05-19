using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            var product = new Product
            {
                Id = 1,
                Name = "Laptop ASUS",
                Price = 14300
            };
            return View(product);
        }
    }
}
