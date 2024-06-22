
using GMAShop.WebUI.Services.CatalogServices.Product;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial(IProductService productService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await productService.GetProductsWithCategoryByCategoryIdAsync(id);
            return View();
        }
    }
}
