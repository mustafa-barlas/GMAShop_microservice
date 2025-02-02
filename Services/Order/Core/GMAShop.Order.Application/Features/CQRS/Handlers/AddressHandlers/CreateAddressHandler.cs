using GMAShop.Order.Application.Feature.CQRS.Commands.AddressCommands;
using GMAShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressHandler(IRepository<Address> addressRepository)
{
    public async Task Handle(CreateAddressCommand createAddressCommand)
    { 
        
        await addressRepository.CreateAsync(new Address
        {
            City = createAddressCommand.City,
            Detail1 = createAddressCommand.Detail1,
            District = createAddressCommand.District,
            UserId = createAddressCommand.UserId,
            Country = createAddressCommand.Country,
            Description = createAddressCommand.Description,
            Detail2 = createAddressCommand.Detail2,
            Email = createAddressCommand.Email,
            Name = createAddressCommand.Name,
            Phone = createAddressCommand.Phone,
            Surname = createAddressCommand.Surname,
            ZipCode = createAddressCommand.ZipCode
        });
    }
}