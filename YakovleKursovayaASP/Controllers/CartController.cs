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
            var cart = new Cart();
            if (HttpContext.Session.Keys.Contains("cart"))
                cart = HttpContext.Session.Get<Cart>("cart");
            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            var product = await _productService.GetAsync(id);
            if (product == null)
                return BadRequest("Не удалось найти выбранный товар");

            var cart = new Cart();
            if (HttpContext.Session.Keys.Contains("cart"))
                cart = HttpContext.Session.Get<Cart>("cart");

            CartItem item = cart?.Items.FirstOrDefault<CartItem>(i => i.Product.Id == product.Id);
            if (item != null)
            {
                item.Count++;
                item.Summ = item.Product.Price * item.Count;
            }
            else
            {
                cart?.Items.Add(new CartItem
                {
                    Product = product,
                    Count = 1,
                    Summ = product.Price
                });
            }

            cart.Count = 0;
            cart.Summ = 0;
            foreach(CartItem cartItems in cart.Items)
            {
                cart.Count += cartItems.Count;
                cart.Summ += cartItems.Summ;
            }

            HttpContext.Session.Set<Cart>("cart", cart);

            return PartialView("Index", cart);
        }

        public async Task<IActionResult> OrderForm()
        {
            return PartialView("OrderForm");
        }

        public async Task<IActionResult> RemoveItem(int id)
        {
            var product = await _productService.GetAsync(id);
            if (product == null)
                return BadRequest("Не удалось найти выбранный товар");

            var cart = new Cart();
            if (HttpContext.Session.Keys.Contains("cart"))
                cart = HttpContext.Session.Get<Cart>("cart");

            cart.Items.Remove(cart.Items.FirstOrDefault(i => i.Product.Id == id));
            cart.Count = 0;
            cart.Summ = 0;
            foreach (CartItem cartItem in cart.Items)
            {
                cart.Count += cartItem.Count;
                cart.Summ += cartItem.Summ;
            }

            HttpContext.Session.Set<Cart>("cart", cart);

            return PartialView("Index", cart);
        }

        public async Task<IActionResult> ClearCart()
        {

            var cart = new Cart();
            if (HttpContext.Session.Keys.Contains("cart"))
                cart = HttpContext.Session.Get<Cart>("cart");

            cart.Items.Clear();
            cart.Count = 0;
            cart.Summ = 0;

            HttpContext.Session.Set<Cart>("cart", cart);

            return PartialView("Index", cart);
        }

        public async Task<IActionResult> GetCartLength()
        {
            int? result = 0;
            if (HttpContext.Session.Keys.Contains("cart"))
                result = HttpContext.Session.Get<Cart>("cart")?.Count;
            
            return Ok(result);
        }

        public async Task<IActionResult> ReduceItem(int id)
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("cart"))
                cart = HttpContext.Session.Get<Cart>("cart");

            CartItem item = cart?.Items.FirstOrDefault<CartItem>(i => i.Product.Id == id);
            if (item != null)
            {
                item.Count--;
                item.Summ = item.Product.Price * item.Count;
            }

            cart.Items.RemoveAll(i => i.Count == 0);
            cart.Count = 0;
            cart.Summ = 0;
            foreach (CartItem cartItem in cart.Items)
            {
                cart.Count += cartItem.Count;
                cart.Summ += cartItem.Summ;
                if (cartItem.Count == 0)
                    cart.Items.Remove(cartItem);
            }

            HttpContext.Session.Set<Cart>("cart", cart);

            return PartialView("Index", cart);
        }

        public async Task<IActionResult> ChangeValue(int id, int value)
        {
            Cart cart = new Cart();
            if (HttpContext.Session.Keys.Contains("cart"))
                cart = HttpContext.Session.Get<Cart>("cart");

            CartItem item = cart?.Items.FirstOrDefault<CartItem>(i => i.Product.Id == id);
            if (item != null)
            {
                item.Count = value;
                item.Summ = item.Product.Price * item.Count;
            }

            cart.Items.RemoveAll(i => i.Count == 0);
            cart.Count = 0;
            cart.Summ = 0;
            foreach (CartItem cartItem in cart.Items)
            {
                cart.Count += cartItem.Count;
                cart.Summ += cartItem.Summ;
                if (cartItem.Count == 0)
                    cart.Items.Remove(cartItem);
            }

            HttpContext.Session.Set<Cart>("cart", cart);

            return PartialView("Index", cart);
        }
    }
}
