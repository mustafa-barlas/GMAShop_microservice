using GMAShop.Order.Application.Feature.Mediator.Queries.OrderingQueries;
using GMAShop.Order.Application.Feature.Mediator.Results.OrderingResults;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;
using MediatR;

namespace GMAShop.Order.Application.Feature.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    private readonly IRepository<Ordering> _repository;

    public GetOrderingQueryHandler(IRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetOrderingQueryResult
        {
            UserId = x.UserId,
            OrderDate = x.OrderDate,
            OrderingId = x.OrderingId,
            TotalPrice = x.TotalPrice
        }).ToList();
    }
}