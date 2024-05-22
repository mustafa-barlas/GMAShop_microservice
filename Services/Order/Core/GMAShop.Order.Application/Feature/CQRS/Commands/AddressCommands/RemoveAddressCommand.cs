namespace GMAShop.Order.Application.Feature.CQRS.Commands.AddressCommands;

public class RemoveAddressCommand
{
    public RemoveAddressCommand(int addressId)
    {
        AddressId = addressId;
    }

    public int AddressId { get; set; }

}