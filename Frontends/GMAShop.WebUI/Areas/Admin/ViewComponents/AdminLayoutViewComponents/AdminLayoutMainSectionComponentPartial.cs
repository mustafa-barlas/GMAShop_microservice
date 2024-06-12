using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;

public class AdminLayoutMainSectionComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}