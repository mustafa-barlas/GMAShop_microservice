using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.ProductListViewComponents;

public class _ProductListColorFilterComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}