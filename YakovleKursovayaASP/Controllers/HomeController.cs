using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YakovleKursovayaASP.Models;

namespace YakovleKursovayaASP.Controllers
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
            List<Base> list = new List<Base>()
            {
                new ArtisticBook()
                {
                    Id = 1,
                    Weight = 1,
                    Size = "1",
                    Brand = "1",
                    Photo = "1",
                    Name = "1",
                    Price = 10,
                    ProductType = ProductType.ArtisticBook
                },
                new ArtisticBook()
                {
                    Id = 2,
                    Weight = 2,
                    Size = "2",
                    Brand = "2",
                    Photo = "2",
                    Price = 20,
                    Name = "2",
                    ProductType = ProductType.BoardGame
                },
                new ArtisticBook()
                {
                    Id = 3,
                    Weight = 3,
                    Size = "3",
                    Brand = "3",
                    Photo = "3",
                    Name = "3",
                    Price = 30,
                    ProductType = ProductType.StudingBook
                },
            };
            return View(list);
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
    }
}
