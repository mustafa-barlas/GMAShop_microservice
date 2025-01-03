
using GMAShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Controllers
{
    public class UserController(IUserService userService) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await userService.GetUserInfo();
            return View(values);
        }
    }
}
