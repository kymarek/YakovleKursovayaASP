

using Microsoft.AspNetCore.Mvc;
using YakovleKursovayaASP.Models;
using YakovleKursovayaASP.Services;

namespace YakovleKursovayaASP.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductService _productService;

        public CartController(ProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            var model = HttpContext.Session.Get<Cart>("Cart");
            return View(model);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _productService.GetAsync(id);
            if (product == null)
                return BadRequest("Не удалось найти выбранный товар");

            var cart = new List<Product>();
            if (HttpContext.Session.Keys.Contains("cart"))
                cart = HttpContext.Session.Get<List<Product>>("cart");

            cart?.Add(product);
            HttpContext.Session.Set<List<Product>>("cart", cart);

            return Ok("Выполнено успешно");
        }

        public async Task<IActionResult> GetCartLength()
        {
            int result = 0;
            if (HttpContext.Session.Keys.Contains("cart"))
                result = HttpContext.Session.Get<List<Product>>("cart").Count;

            return Ok(result);
        }
    }
}
