using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
