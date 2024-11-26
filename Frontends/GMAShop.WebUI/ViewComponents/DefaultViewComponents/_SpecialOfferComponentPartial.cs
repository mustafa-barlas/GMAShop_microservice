using GMAShop.WebUI.Services.CatalogServices.SpecialOffer;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _SpecialOfferComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;
        public _SpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View();
        }
    }
}
