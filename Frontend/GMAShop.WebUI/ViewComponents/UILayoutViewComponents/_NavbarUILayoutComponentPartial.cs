using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.CatalogDtos.CategoryDtos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using GMAShop.WebUI.Services.CatalogServices.CategoryServices;

namespace GMAShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public _NavbarUILayoutComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}