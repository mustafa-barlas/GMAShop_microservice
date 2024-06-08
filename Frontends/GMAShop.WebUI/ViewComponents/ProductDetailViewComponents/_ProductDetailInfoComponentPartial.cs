using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailInfoComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}