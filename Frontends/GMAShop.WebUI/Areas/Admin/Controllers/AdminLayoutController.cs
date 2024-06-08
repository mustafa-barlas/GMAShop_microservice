using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminLayoutController : Controller
{
    // GET
    public IActionResult _AdminLayout()
    {
        return View();
    }
}