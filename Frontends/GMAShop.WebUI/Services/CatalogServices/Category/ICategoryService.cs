using GMAShop.DtoLayer.CatalogDtos.CategoryDtos;

namespace GMAShop.WebUI.Services.CatalogServices.Category;

public interface ICategoryService
{
    Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
    Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
    Task DeleteCategoryAsync(string id);
    Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id);
}