using GMAShop.Order.Application.Feature.CQRS.Commands.AddressCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Feature.CQRS.Handlers.AddressHandlers;

public class CreateAddressHandler
{
    private readonly IRepository<Address> _addressRepository;

    public CreateAddressHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(CreateAddressCommand createAddressCommand)
    {
        await _addressRepository.CreateAsync(new Address()
        {
            UserId = createAddressCommand.UserId,
            City = createAddressCommand.City,
            Detail = createAddressCommand.Detail,
            District = createAddressCommand.District
        });
    }
}