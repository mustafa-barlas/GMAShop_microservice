using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _OrderDetailComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
