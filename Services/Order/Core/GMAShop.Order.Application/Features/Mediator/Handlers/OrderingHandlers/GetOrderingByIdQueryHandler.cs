using GMAShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using GMAShop.Order.Application.Features.Mediator.Results.OrderingResults;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;
using MediatR;

namespace GMAShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IRepository<Ordering> _repository;

    public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        return new GetOrderingByIdQueryResult()
        {
            UserId = values.UserId,
            OrderDate = values.OrderDate,
            OrderingId = values.OrderingId,
            TotalPrice = values.TotalPrice
        };
    }
}