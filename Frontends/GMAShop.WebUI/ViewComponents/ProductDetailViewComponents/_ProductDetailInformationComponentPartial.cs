using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.ProductDetailViewComponents;

public class _ProductDetailInformationComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View();
    }
}