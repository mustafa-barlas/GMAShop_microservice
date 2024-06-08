using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.ContactViewComponents;

public class _ContactDetailComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}