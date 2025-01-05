using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.CatalogDtos.BrandDtos;
using GMAShop.WebUI.Services.CatalogServices.BrandServices;
using Newtonsoft.Json;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _VendorDefaultComponentPartial : ViewComponent
    {
        private readonly IBrandService _brandService;
        public _VendorDefaultComponentPartial(IBrandService brandService)
        {
            _brandService = brandService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _brandService.GetAllBrandAsync();
            return View(values);
        }
    }
}
