using GMAShop.WebUI.Services.CatalogServices.FeatureSlider;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
    }
}