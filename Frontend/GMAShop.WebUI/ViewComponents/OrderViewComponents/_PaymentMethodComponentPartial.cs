using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.OrderViewComponents
{
    public class _PaymentMethodComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
