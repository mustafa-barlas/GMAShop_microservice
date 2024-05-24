using GMAShop.Order.Application.Feature.Mediator.Commands.OrderingCommands;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;
using MediatR;

namespace GMAShop.Order.Application.Feature.Mediator.Handlers.OrderingHandlers;

public class RemoveOrderingQueryHandler : IRequestHandler<RemoveOrderingCommand>
{
    private readonly IRepository<Ordering> _repository;

    public RemoveOrderingQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetByIdAsync(request.Id);
        await _repository.DeleteAsync(value);
    }
}