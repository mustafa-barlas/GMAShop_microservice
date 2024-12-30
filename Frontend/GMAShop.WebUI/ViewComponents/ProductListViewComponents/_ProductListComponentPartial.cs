using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.CatalogDtos.ProductDtos;
using GMAShop.WebUI.Services.CatalogServices.ProductServices;
using Newtonsoft.Json;

namespace GMAShop.WebUI.ViewComponents.ProductListViewComponents
{
    public class _ProductListComponentPartial : ViewComponent
    {
        private readonly IProductService _productService;
        public _ProductListComponentPartial(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _productService.GetProductsWithCategoryByCatetegoryIdAsync(id);
            return View(values);
        }
    }
}
