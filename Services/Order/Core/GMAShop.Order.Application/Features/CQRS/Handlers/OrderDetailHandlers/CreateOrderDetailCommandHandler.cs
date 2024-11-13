using GMAShop.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderDetailCommand command)
    {
        await _repository.CreateAsync(new OrderDetail()
        {
            ProductId = command.ProductId,
            ProductAmount = command.ProductAmount,
            OrderingId = command.OrderingId,
            ProductPrice = command.ProductPrice,
            ProductTotalPrice = command.ProductTotalPrice,
            ProductName = command.ProductName
        });
    }
}