using GMAShop.DtoLayer.CatalogDtos.FeatureSliderDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.FeatureSlider;

public class FeatureSliderService(HttpClient httpClient) : IFeatureSliderService
{
    public async Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync()
    {
        return await httpClient.GetAndRead<List<ResultFeatureSliderDto>>("FeatureSliders");
    }

    public async Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto)
    {
         await httpClient.Post("FeatureSliders", createFeatureSliderDto);
      
    }

    public async Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto)
    {
       await httpClient.Put("FeatureSliders", updateFeatureSliderDto);
       
    }

    public async Task DeleteFeatureSliderAsync(string id)
    {
        await httpClient.Delete($"FeatureSliders?id={id}");
    }

    public async Task<ResultFeatureSliderDto> GetByIdFeatureSliderAsync(string id)
    {
        return await httpClient.GetAndRead<ResultFeatureSliderDto>($"FeatureSliders/{id}");
    }
}