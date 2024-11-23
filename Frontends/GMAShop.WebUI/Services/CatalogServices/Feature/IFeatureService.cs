using GMAShop.DtoLayer.CatalogDtos.FeatureDtos;

namespace GMAShop.WebUI.Services.CatalogServices.Feature;

public interface IFeatureService
{
    Task<List<ResultFeatureDto>> GetAllFeatureAsync();
    Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
    Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
    Task DeleteFeatureAsync(string id);
    Task<UpdateFeatureDto> GetByIdFeatureAsync(string id);
}