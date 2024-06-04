using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Controllers;

public class UILayoutController : Controller
{
    // GET
    public IActionResult _UILayout()
    {
        return View();
    }
}