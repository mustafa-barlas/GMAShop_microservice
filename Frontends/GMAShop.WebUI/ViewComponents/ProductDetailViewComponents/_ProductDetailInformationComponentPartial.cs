using GMAShop.WebUI.Services.CatalogServices.ProductDetail;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial(IProductDetailService productDetailService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
        }
    }
}