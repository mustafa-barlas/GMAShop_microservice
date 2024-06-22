
using GMAShop.WebUI.Services.CatalogServices.About;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _FooterUILayoutComponentPartial(IAboutService aboutService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
