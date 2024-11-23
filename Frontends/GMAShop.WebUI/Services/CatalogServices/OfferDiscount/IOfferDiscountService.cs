using GMAShop.DtoLayer.CatalogDtos.OfferDiscountDtos;

namespace GMAShop.WebUI.Services.CatalogServices.OfferDiscount;

public interface IOfferDiscountService
{
    Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
    Task CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
    Task UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
    Task DeleteOfferDiscountAsync(string id);
    Task<UpdateOfferDiscountDto> GetByIdOfferDiscountAsync(string id);
}