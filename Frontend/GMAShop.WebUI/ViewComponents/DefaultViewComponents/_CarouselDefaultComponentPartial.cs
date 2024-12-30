using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using GMAShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using Newtonsoft.Json;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CarouselDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureSliderService _featureSliderService;
        public _CarouselDefaultComponentPartial(IFeatureSliderService featureSliderService)
        {
            _featureSliderService = featureSliderService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values =await _featureSliderService.GetAllFeatureSliderAsync();
            return View(values);
        }
    }
}
