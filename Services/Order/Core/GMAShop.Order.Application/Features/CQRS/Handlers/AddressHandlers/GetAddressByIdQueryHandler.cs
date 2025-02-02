using GMAShop.Order.Application.Feature.CQRS.Queries.AddressQueries;
using GMAShop.Order.Application.Feature.CQRS.Results.AddressResults;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IRepository<Address> _addressRepository;

    public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
    {
        var values = await _addressRepository.GetByIdAsync(getAddressByIdQuery.AddressId);
        return new()
        {
            UserId = values.UserId,
            AddressId = values.AddressId,
            City = values.City,
            District = values.District,
            Detail = values.Detail1
        };
    }
}