using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents;

public class _SpecialOfferComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}