using GMAShop.DtoLayer.CatalogDtos.FeatureDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.Feature;

public class FeatureService(HttpClient httpClient) : IFeatureService
{
    public async Task<List<ResultFeatureDto>> GetAllFeatureAsync()
    {
        return await httpClient.GetAndRead<List<ResultFeatureDto>>("Features");
    }

    public async Task CreateFeatureAsync(CreateFeatureDto createFeatureDto)
    {
         await httpClient.Post("Features", createFeatureDto);
      
    }

    public async Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto)
    {
       await httpClient.Put("Features", updateFeatureDto);
       
    }

    public async Task DeleteFeatureAsync(string id)
    {
        await httpClient.Delete($"Features?id={id}");
    }

    public async Task<ResultFeatureDto> GetByIdFeatureAsync(string id)
    {
        return await httpClient.GetAndRead<ResultFeatureDto>($"Features/{id}");
    }
}