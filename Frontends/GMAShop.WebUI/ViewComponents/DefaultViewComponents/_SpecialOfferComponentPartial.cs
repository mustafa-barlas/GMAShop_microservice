using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.CatalogServices.SpecialOfferServices;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial(ISpecialOfferService specialOfferService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
