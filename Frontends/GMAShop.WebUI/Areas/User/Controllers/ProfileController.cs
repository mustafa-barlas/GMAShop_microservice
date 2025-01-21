using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.User.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
