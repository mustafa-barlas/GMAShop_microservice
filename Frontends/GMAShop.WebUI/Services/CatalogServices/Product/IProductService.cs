using GMAShop.DtoLayer.CatalogDtos.ProductDtos;

namespace GMAShop.WebUI.Services.CatalogServices.Product;

public interface IProductService
{
    Task<List<ResultProductDto>> GetAllProductAsync();
    Task CreateProductAsync(CreateProductDto createProductDto);
    Task UpdateProductAsync(UpdateProductDto updateProductDto);
    Task DeleteProductAsync(string id);
    Task<ResultProductDto> GetByIdProductAsync(string id);
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync();
    Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCategoryIdAsync(string categoryId);
}