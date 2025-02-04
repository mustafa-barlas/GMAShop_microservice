using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.Interfaces;
using GMAShop.WebUI.Services.OrderServices.OrderOrderingServices;

namespace GMAShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrderController(IOrderOrderingService orderOrderingService, IUserService userService)
        : Controller
    {
        public async Task<IActionResult> MyOrderList()
        {
            var user = await userService.GetUserInfo();
            var values = await orderOrderingService.GetOrderingByUserId(user.Id);
            return View(values);
        }
    }
}