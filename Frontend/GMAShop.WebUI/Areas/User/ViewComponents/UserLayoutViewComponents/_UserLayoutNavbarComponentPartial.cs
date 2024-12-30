using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Areas.User.ViewComponents.UserLayoutViewComponents
{
    public class _UserLayoutNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
