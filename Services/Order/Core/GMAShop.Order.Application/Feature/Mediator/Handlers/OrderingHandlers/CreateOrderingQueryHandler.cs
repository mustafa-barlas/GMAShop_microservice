using GMAShop.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;
using MediatR;

namespace GMAShop.Order.Application.Feature.Mediator.Handlers.OrderingHandlers;

public class CreateOrderingQueryHandler : IRequestHandler<CreateOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public CreateOrderingQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Ordering()
        {
            OrderDate = request.OrderDate,
            UserId = request.UserId,
            TotalPrice = request.TotalPrice
        });
    }
}