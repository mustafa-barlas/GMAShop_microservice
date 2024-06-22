using GMAShop.DtoLayer.CatalogDtos.ProductImageDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.ProductImage;

public class ProductImageService(HttpClient httpClient) : IProductImageService
{
    public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
    {
        return await httpClient.GetAndRead<List<ResultProductImageDto>>("ProductImages");
    }

    public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
    {
        await httpClient.Post("ProductImages", createProductImageDto);
    }

    public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
    {
        await httpClient.Put("ProductImages", updateProductImageDto);
    }

    public async Task DeleteProductImageAsync(string id)
    {
        await httpClient.Delete($"ProductImages?id={id}");
    }

    Task<GetByIdProductImageDto> IProductImageService.GetByIdProductImageAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdProductImageDto> GetByProductIdProductImageAsync(string id)
    {
        throw new NotImplementedException();
    }

    public async Task<ResultProductImageDto> GetByIdProductImageAsync(string id)
    {
        return await httpClient.GetAndRead<ResultProductImageDto>($"ProductImages/{id}");
    }
}