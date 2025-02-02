using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.CargoServices.CargoCustomerServices;
using GMAShop.WebUI.Services.UserIdentityServices;

namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
        : Controller
    {
        public async Task<IActionResult> UserList()
        {
            var values = await userIdentityService.GetAllUserListAsync();
            return View(values);
        }

        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var values =await cargoCustomerService.GetByIdCargoCustomerInfoAsync(id);
            return View(values);
        }
    }
}
