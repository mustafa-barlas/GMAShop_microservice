using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        ViewBag.v0 = "Anasayfa";
        ViewBag.v1 = "Kategoriler";
        ViewBag.v2 = "Kategori Listesi";
        ViewBag.v3 = "Kategori İşlemleri";
        return View();
    }
}