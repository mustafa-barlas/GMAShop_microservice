﻿
using GMAShop.WebUI.Services.CatalogServices.Product;
using Microsoft.AspNetCore.Mvc;

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
