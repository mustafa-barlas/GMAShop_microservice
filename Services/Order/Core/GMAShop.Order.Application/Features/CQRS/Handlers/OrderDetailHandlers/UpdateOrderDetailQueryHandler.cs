using GMAShop.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public UpdateOrderDetailQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderDetailCommand command)
    {
        var value = await _repository.GetByIdAsync(command.OrderingId);
        value.OrderingId = command.OrderingId;
        value.ProductId = command.ProductId;
        value.ProductName = command.ProductName;
        value.ProductPrice = command.ProductPrice;
        value.ProductAmount = command.ProductAmount;
        value.ProductTotalPrice = command.ProductTotalPrice;
        await _repository.UpdateAsync(value);
    }
}