using GMAShop.Order.Application.Feature.CQRS.Commands.AddressCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class RemoveAddressHandler
{
    private readonly IRepository<Address> _addressRepository;

    public RemoveAddressHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(RemoveAddressCommand removeAddressCommand)
    {
        var value = await _addressRepository.GetByIdAsync(removeAddressCommand.AddressId);
        await _addressRepository.DeleteAsync(value);
    }
}