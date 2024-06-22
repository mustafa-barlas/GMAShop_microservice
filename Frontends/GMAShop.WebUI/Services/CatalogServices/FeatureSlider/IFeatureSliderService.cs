using GMAShop.DtoLayer.CatalogDtos.FeatureSliderDtos;

namespace GMAShop.WebUI.Services.CatalogServices.FeatureSlider;

public interface IFeatureSliderService
{
    Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();
    Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
    Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
    Task DeleteFeatureSliderAsync(string id);
    Task<ResultFeatureSliderDto> GetByIdFeatureSliderAsync(string id);
}