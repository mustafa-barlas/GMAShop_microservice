using GMAShop.DtoLayer.CatalogDtos.AboutDtos;

namespace GMAShop.WebUI.Services.CatalogServices.About;

public interface IAboutService
{
    Task<List<ResultAboutDto>> GetAllAboutAsync();
    Task CreateAboutAsync(CreateAboutDto createAboutDto);
    Task UpdateAboutAsync(UpdateAboutDto updateAboutDto);
    Task DeleteAboutAsync(string id);
    Task<UpdateAboutDto> GetByIdAboutAsync(string id);
}