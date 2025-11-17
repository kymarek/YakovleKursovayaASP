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
        private readonly ArtisticBookService _artisticBookService;
        private readonly BoardGameService _boardGameService;
        private readonly StudingBookService _studingBookService;

        public HomeController(ILogger<HomeController> logger, ProductService productService, ArtisticBookService artisticBookService, BoardGameService boardGameService, StudingBookService studingBookService)
        {
            _logger = logger;
            _productService = productService;
            _artisticBookService = artisticBookService;
            _boardGameService = boardGameService;
            _studingBookService = studingBookService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _productService.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id, ProductType productType)
        {
            object value;
            switch (productType)
            {
                case ProductType.ArtisticBook:
                    value = await _artisticBookService.GetViewAsync(id);
                    break;
                case ProductType.BoardGame:
                    value = await _boardGameService.GetViewAsync(id);
                    break;
                case ProductType.StudingBook:
                    value = await _studingBookService.GetViewAsync(id);
                    break;
                default:
                    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View(value);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
