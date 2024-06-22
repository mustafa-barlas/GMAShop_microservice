using GMAShop.WebUI.Services.CatalogServices.Product;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailFeatureComponentPartial(IProductService productService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values=await productService.GetByIdProductAsync(id);
            return View(values);
        }
    }
}
