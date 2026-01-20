using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YakovleKursovayaASP.Models;
using YakovleKursovayaASP.Services;

namespace YakovleKursovayaASP.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult LoginForm()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("LoginForm");
        }

        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            User user = await _userService.GetAsync(loginModel);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Login),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim("City", user.City),
                    new Claim("Phone", user.Phone),
                    new Claim("Surname", user.Surname),
                    new Claim("Name", user.Name),
                    new Claim("Patronymic", user.Patronymic),
                    new Claim("Mail", user.Mail)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, 
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ConfirmRegistration(User user)
        {
            await _userService.InsertAsync(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
