using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PantryWebApp.Models;

namespace PantryWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Index Page
        //Return a view.  Index is "assumed" because we aren't passing anything else
        public IActionResult Index()
        {
            return View();
        }

        //Privacy Page
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        //Error page
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
