using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
