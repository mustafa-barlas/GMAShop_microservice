﻿namespace GMAShop.Order.Application.Feature.CQRS.Commands.AddressCommands;

public class CreateAddressCommand
{
    public string UserId { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Detail { get; set; }
}