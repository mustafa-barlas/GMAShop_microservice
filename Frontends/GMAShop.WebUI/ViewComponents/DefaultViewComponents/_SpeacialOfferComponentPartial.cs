using GMAShop.WebUI.Services.CatalogServices.SpecialOffer;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpeacialOfferComponentPartial(ISpecialOfferService specialOfferService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }
    }
}
