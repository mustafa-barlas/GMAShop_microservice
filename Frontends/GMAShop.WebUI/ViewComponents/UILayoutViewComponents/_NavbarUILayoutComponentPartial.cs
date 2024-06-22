using GMAShop.WebUI.Services.CatalogServices.Category;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial(ICategoryService categoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}