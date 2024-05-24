using GMAShop.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;
using MediatR;

namespace GMAShop.Order.Application.Feature.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingQueryHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public UpdateOrderingQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.OrderingId);

        await _repository.UpdateAsync(new Ordering()
        {
            OrderingId = request.OrderingId,
            OrderDate = request.OrderDate,
            UserId = request.UserId,
            TotalPrice = request.TotalPrice
        });
    }
}