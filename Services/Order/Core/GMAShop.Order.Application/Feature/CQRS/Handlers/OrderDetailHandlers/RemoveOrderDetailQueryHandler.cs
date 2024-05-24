using GMAShop.Order.Application.Feature.CQRS.Commands.OrderDetailCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;

public class RemoveOrderDetailQueryHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public RemoveOrderDetailQueryHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveOrderDetailCommand command)
    {
        var value = await _repository.GetByIdAsync(command.Id);
        await _repository.DeleteAsync(value);
    }
}