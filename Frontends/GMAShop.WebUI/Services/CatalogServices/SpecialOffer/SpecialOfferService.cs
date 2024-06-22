using GMAShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.SpecialOffer;

public class SpecialOfferService(HttpClient httpClient) : ISpecialOfferService
{
    public async Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync()
    {
        return await httpClient.GetAndRead<List<ResultSpecialOfferDto>>("SpecialOffers");
    }

    public async Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto)
    {
        await httpClient.Post("SpecialOffers", createSpecialOfferDto);
    }

    public async Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto)
    {
        await httpClient.Put("SpecialOffers", updateSpecialOfferDto);
    }

    public async Task DeleteSpecialOfferAsync(string id)
    {
        await httpClient.Delete($"SpecialOffers?id={id}");
    }

    public async Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id)
    {
        return await httpClient.GetAndRead<GetByIdSpecialOfferDto>($"SpecialOffers/{id}");
    }
}