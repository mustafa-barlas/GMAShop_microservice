using GMAShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using GMAShop.DtoLayer.CatalogDtos.ProductDtos;
using GMAShop.WebUI.Extensions;


namespace GMAShop.WebUI.Services.CatalogServices.ProductDetail;

public class ProductDetailService(HttpClient httpClient) : IProductDetailService
{
    public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
    {
        return await httpClient.GetAndRead<List<ResultProductDetailDto>>("ProductDetails");
    }

    public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
    {
        await httpClient.Post("ProductDetails", createProductDetailDto);
    }

    public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
    {
        await httpClient.Put("ProductDetails", updateProductDetailDto);
    }

    public async Task DeleteProductDetailAsync(string id)
    {
        await httpClient.Delete($"ProductDetails?id={id}");
    }

    public async Task<GetByIdProductDetailDto> GetByIdProductDetailAsync(string id)
    {
        return await httpClient.GetAndRead<GetByIdProductDetailDto>($"ProductDetails/{id}");
    }


    public async Task<GetByIdProductDetailDto> GetByProductIdProductDetailAsync(string id)
    {
        return await httpClient.GetAndRead<GetByIdProductDetailDto>($"ProductDetails/{id}");
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductsDetailsWithCategoryAsync()
    {
        return await httpClient.GetAndRead<List<ResultProductWithCategoryDto>>("ProductDetails/ProductDetailListWithCategory");
    }

    public async Task<List<ResultProductWithCategoryDto>> GetProductsDetailsWithCategoryByCategoryIdAsync(string 
            categoryId)
    {
        return await httpClient.GetAndRead<List<ResultProductWithCategoryDto>>(
            $"ProductDetails/GetProductDetailsWithCategoryByCategoryIdAsync/{categoryId}");
    }
}