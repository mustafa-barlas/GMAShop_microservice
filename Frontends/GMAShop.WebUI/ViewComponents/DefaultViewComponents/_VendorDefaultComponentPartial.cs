using GMAShop.WebUI.Services.CatalogServices.Brand;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial(IBrandService brandService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await brandService.GetAllBrandAsync();
            return View(values);
        }
    }
}
