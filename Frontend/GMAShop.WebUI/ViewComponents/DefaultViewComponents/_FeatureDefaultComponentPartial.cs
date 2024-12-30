using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.CatalogDtos.FeatureDtos;
using GMAShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;
        public _FeatureDefaultComponentPartial(IFeatureService featureService)
        {
            _featureService = featureService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
