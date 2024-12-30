using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListPaginationComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
