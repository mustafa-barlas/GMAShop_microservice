using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using GMAShop.WebUI.Services.CatalogServices.ProductDetailServices;
using Newtonsoft.Json;

namespace GMAShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailInformationComponentPartial : ViewComponent
    {
        private readonly IProductDetailService _productDetailService;
        public _ProductDetailInformationComponentPartial(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {

            var values =await _productDetailService.GetByProductIdProductDetailAsync(id);
            return View(values);
        }
    }
}
