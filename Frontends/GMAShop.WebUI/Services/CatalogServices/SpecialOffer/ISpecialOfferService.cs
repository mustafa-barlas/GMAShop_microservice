using GMAShop.DtoLayer.CatalogDtos.SpecialOfferDtos;

namespace GMAShop.WebUI.Services.CatalogServices.SpecialOffer;

public interface ISpecialOfferService
{
    Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
    Task CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
    Task UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
    Task DeleteSpecialOfferAsync(string id);
    Task<GetByIdSpecialOfferDto> GetByIdSpecialOfferAsync(string id);
}