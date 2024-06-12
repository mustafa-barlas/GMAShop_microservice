using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutHeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}