using GMAShop.DtoLayer.CatalogDtos.CategoryDtos;
using GMAShop.DtoLayer.CatalogDtos.ProductDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.Product;

public class ProductService(HttpClient httpClient) : IProductService
{
    public async Task<List<ResultProductDto>> GetAllProductAsync()
    {
        return await httpClient.GetAndRead<List<ResultProductDto>>("products");
    }

    public async Task CreateProductAsync(CreateProductDto createProductDto)
    {
        await httpClient.Post("products", createProductDto);
    }

    public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        await httpClient.Put("products", updateProductDto);
    }

    public async Task DeleteProductAsync(string id)
    {
        await httpClient.Delete($"products?id={id}");
    }

    public async Task<ResultProductDto> GetByIdProductAsync(string id)
    {
        return await httpClient.GetAndRead<ResultProductDto>($"products/{id}");
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
    {
        return await httpClient.GetAndRead<List<ResultProductWithCategoryDto>>("Products/ProductListWithCategory");
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId)
    {
        return await httpClient.GetAndRead<List<ResultProductWithCategoryDto>>(
            $"products/GetProductsWithCategoryByCategoryIdAsync/{categoryId}");
    }
}