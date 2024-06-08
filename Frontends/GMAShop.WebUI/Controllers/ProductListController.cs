using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Controllers;

public class ProductListController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult ProductDetail()
    {
        return View();
    }
}