using GMAShop.DtoLayer.CatalogDtos.BrandDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.Brand;

public class BrandService(HttpClient httpClient) : IBrandService
{
    public async Task<List<ResultBrandDto>> GetAllBrandAsync()
    {
        return await httpClient.GetAndRead<List<ResultBrandDto>>("Brands");
    }

    public async Task CreateBrandAsync(CreateBrandDto createBrandDto)
    {
         await httpClient.Post("Brands", createBrandDto);
      
    }

    public async Task UpdateBrandAsync(UpdateBrandDto updateBrandDto)
    {
       await httpClient.Put("Brands", updateBrandDto);
       
    }

    public async Task DeleteBrandAsync(string id)
    {
        await httpClient.Delete($"Brands?id={id}");
    }

    public async Task<ResultBrandDto> GetByIdBrandAsync(string id)
    {
        return await httpClient.GetAndRead<ResultBrandDto>($"Brands/{id}");
    }
}