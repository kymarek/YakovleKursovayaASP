using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YakovleKursovayaASP.Models;
using YakovleKursovayaASP.Services;

namespace YakovleKursovayaASP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductService _productService;

        public HomeController(ILogger<HomeController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var result = await _productService.GetAsync(id);
            return View(result);
        }

        public async Task<IActionResult> GetByFilters(Filters filters)
        {
            var result = await _productService.GetByFiltersAsync(filters);
            return PartialView("Index", result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
