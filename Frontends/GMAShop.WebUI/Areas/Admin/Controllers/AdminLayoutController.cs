using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminLayout")]
    [Authorize]

    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
