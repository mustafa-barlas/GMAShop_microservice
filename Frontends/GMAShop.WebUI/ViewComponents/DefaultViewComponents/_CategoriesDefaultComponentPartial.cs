using GMAShop.WebUI.Services.CatalogServices.Category;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _CategoriesDefaultComponentPartial(ICategoryService categoryService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
