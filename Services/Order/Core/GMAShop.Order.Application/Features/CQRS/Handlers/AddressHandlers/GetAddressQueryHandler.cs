using GMAShop.Order.Application.Feature.CQRS.Results.AddressResults;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressQueryHandler
{
    private readonly IRepository<Address> _repository;

    public GetAddressQueryHandler(IRepository<Address> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAddressQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetAddressQueryResult()
        {
            UserId = x.UserId,
            AddressId = x.AddressId,
            City = x.City,
            District = x.District,
            Detail = x.Detail1
        }).ToList();
    }
}