using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace GMAShop.WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(IUserService userService, IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IActionResult> Index()
        {
            var values = await _userService.GetUserInfo();
            return View(values);
        }

        public async Task<IActionResult> Logout()
        {
            // Kullanıcıyı oturumdan çıkar
            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            // Oturum bilgilerini temizle
            var currentUser = _httpContextAccessor.HttpContext.User;
            if (currentUser != null && currentUser.Identity.IsAuthenticated)
            {
                // Çıkış yapıldığında token bilgilerini de temizle
                 _httpContextAccessor.HttpContext.Response.Cookies.Delete("GMAShopJwt");
                 _httpContextAccessor.HttpContext.Response.Cookies.Delete("GMAShopCookie");
            }
            return RedirectToAction("Index", "Login");
        }
    }
}
