using GMAShop.Catalog.Dtos.CategoryDtos;
using GMAShop.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class CategoriesController(ICategoryService categoryService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            var values = await categoryService.GetAllCategoryAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var value = await categoryService.GetByIdCategoryAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Successful");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await categoryService.DeleteCategoryAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok();
        }
    }
}
