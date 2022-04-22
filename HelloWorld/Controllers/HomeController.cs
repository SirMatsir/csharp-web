using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                return View("Thanks", guestResponse);
            }
            else // stay on the page if error validation happens
            {
                return View();
            }
        }

        // For product view
        [HttpGet]
        public IActionResult Product()
        {
            var myProduct = new Product
            {
                ProductId = 1,
                Name = "Kayak",
                Description = "A boat for one person",
                Category = "water-sports",
                Price = 200m, // decimal type
            };

            return View(myProduct);
        }

        // for products collection

        [HttpGet]
        public IActionResult Products()
        {
            var products = new Models.Product[]
            {
                // for exercise added the ProductCount at the tail ends...
        new Product{ ProductId = 1, Name = "First One", Price = 1.11m, ProductCount=0},
        new Product{ ProductId = 2, Name="Second One", Price = 2.22m, ProductCount=1},
        new Product{ ProductId = 3, Name="Third One", Price = 3.33m, ProductCount=10},
        new Product{ ProductId = 4, Name="Fourth One", Price = 4.44m, ProductCount=100},

            };

            return View(products);
        }

    }
}