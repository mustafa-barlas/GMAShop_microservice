using GMAShop.DtoLayer.CatalogDtos.ProductDetailDtos;

namespace GMAShop.WebUI.Services.CatalogServices.ProductDetail;

public interface IProductDetailService
{
    Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
    Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
    Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
    Task DeleteProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id);
    Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id);
}