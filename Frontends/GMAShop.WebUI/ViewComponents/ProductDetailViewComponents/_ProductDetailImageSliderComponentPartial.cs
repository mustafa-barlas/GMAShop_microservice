using GMAShop.WebUI.Services.CatalogServices.ProductImage;
using Microsoft.AspNetCore.Mvc;


namespace GMAShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailImageSliderComponentPartial(IProductImageService productImageService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await productImageService.GetByProductIdProductImageAsync(id);
            return View(values);
        }
    }
}
