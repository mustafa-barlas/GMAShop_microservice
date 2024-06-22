using GMAShop.DtoLayer.CatalogDtos.OfferDiscountDtos;
using GMAShop.WebUI.Extensions;

namespace GMAShop.WebUI.Services.CatalogServices.OfferDiscount;

public class OfferDiscountService(HttpClient httpClient) : IOfferDiscountService
{
    public async Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync()
    {
        return await httpClient.GetAndRead<List<ResultOfferDiscountDto>>("OfferDiscounts");
    }

    public async Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto)
    {
         await httpClient.Post("OfferDiscounts", createOfferDiscountDto);
      
    }

    public async Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto)
    {
       await httpClient.Put("OfferDiscounts", updateOfferDiscountDto);
       
    }

    public async Task DeleteOfferDiscountAsync(string id)
    {
        await httpClient.Delete($"OfferDiscounts?id={id}");
    }

    public async Task<ResultOfferDiscountDto> GetByIdOfferDiscountAsync(string id)
    {
        return await httpClient.GetAndRead<ResultOfferDiscountDto>($"OfferDiscounts/{id}");
    }
}