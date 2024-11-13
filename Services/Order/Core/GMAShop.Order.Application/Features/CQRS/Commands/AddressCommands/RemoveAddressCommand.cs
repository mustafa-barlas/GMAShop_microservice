﻿namespace GMAShop.Order.Application.Feature.CQRS.Commands.AddressCommands;

public class RemoveAddressCommand
{
    public int AddressId { get; set; }
    public RemoveAddressCommand(int addressId)
    {
        AddressId = addressId;
    }
}