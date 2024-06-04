using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Controllers;

public class DefaultController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}