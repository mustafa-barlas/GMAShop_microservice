using GMAShop.Order.Application.Feature.CQRS.Commands.AddressCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Feature.CQRS.Handlers.AddressHandlers;

public class UpdateAddressHandler
{
    private readonly IRepository<Address> _addressRepository;

    public UpdateAddressHandler(IRepository<Address> addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task Handle(UpdateAddressCommand updateAddressCommand)
    {
        var value = await _addressRepository.GetByIdAsync(updateAddressCommand.AddressId);

        value.Detail = updateAddressCommand.Detail;
        value.District = updateAddressCommand.District;
        value.UserId = updateAddressCommand.UserId;
        value.City = updateAddressCommand.City;
        await _addressRepository.UpdateAsync(value);
    }
}