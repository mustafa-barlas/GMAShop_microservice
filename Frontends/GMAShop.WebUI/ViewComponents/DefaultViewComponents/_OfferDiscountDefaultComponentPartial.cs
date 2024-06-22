using GMAShop.WebUI.Services.CatalogServices.OfferDiscount;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _OfferDiscountDefaultComponentPartial(IOfferDiscountService offerDiscountService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await offerDiscountService.GetAllOfferDiscountAsync();
            return View(values);
        }
    }
}
