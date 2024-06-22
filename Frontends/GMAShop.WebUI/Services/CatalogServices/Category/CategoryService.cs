using GMAShop.DtoLayer.CatalogDtos.CategoryDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.Category;

public class CategoryService(HttpClient httpClient) : ICategoryService
{
    public async Task<List<ResultCategoryDto>> GetAllCategoryAsync()
    {
        return await httpClient.GetAndRead<List<ResultCategoryDto>>("categories");
    }

    public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
    {
        await httpClient.Post("categories", createCategoryDto);
    }

    public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
    {
       await httpClient.Put("categories", updateCategoryDto);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await httpClient.Delete($"categories?id={id}");
    }

    public async Task<GetByIdCategoryDto> GetByIdCategoryAsync(string id)
    {
        return await httpClient.GetAndRead<GetByIdCategoryDto>($"categories/{id}");
    }
}