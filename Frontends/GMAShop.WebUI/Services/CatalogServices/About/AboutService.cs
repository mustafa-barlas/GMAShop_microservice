using GMAShop.DtoLayer.CatalogDtos.AboutDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.About;

public class AboutService(HttpClient httpClient) : IAboutService
{
    public async Task<List<ResultAboutDto>> GetAllAboutAsync()
    {
        return await httpClient.GetAndRead<List<ResultAboutDto>>("Abouts");
    }

    public async Task CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        await httpClient.Post("Abouts", createAboutDto);
      
    }

    public async Task UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
      await httpClient.Put("Abouts", updateAboutDto);
       
    }

    public async Task DeleteAboutAsync(string id)
    {
        await httpClient.Delete($"Abouts?id={id}");
    }

    public async Task<ResultAboutDto> GetByIdAboutAsync(string id)
    {
        return await httpClient.GetAndRead<ResultAboutDto>($"Abouts/{id}");
    }
}