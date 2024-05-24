﻿namespace GMAShop.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;

public class UpdateOrderDetailCommand
{
    public int OrderDetail { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductTotalPrice { get; set; }
    public int OrderingId { get; set; }
}