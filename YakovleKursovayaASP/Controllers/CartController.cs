using Microsoft.AspNetCore.Mvc;
using YakovleKursovayaASP.Models;

namespace YakovleKursovayaASP.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            //var model = HttpContext.Session.Get<Cart>("Cart");
            var model = new Cart(); ;
            return View(model);
        }
    }
}
