using GMAShop.WebUI.Services.CatalogServices.Feature;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureDefaultComponentPartial(IFeatureService featureService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
