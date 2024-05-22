using GMAShop.Order.Application.Feature.CQRS.Results.AddressResults;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Feature.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler
{
    private readonly IRepository<Address> _addressRepository;

    public GetAddressQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<List<GetAddressQueryResult>> Handle(GetAddressQueryResult getAddressQueryResult)
    {
        var values = await _addressRepository.GetAllAsync();

        return values.Select(x => new GetAddressQueryResult()
        {
            UserId = x.UserId,
            AddressId = x.AddressId,
            City = x.City,
            District = x.District,
            Detail = x.Detail
        }).ToList();
    }
}