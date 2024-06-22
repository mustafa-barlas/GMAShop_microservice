using GMAShop.WebUI.Services.CatalogServices.Product;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _FeatureProductsDefaultComponentPartial(IProductService productService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await productService.GetAllProductAsync();
            return View(values);
        }
    }
}
