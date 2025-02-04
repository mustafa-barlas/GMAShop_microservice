using GMAShop.Order.Application.Feature.Mediator.Results.OrderingResults;
using GMAShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;
using MediatR;

namespace GMAShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingQueryHandler(IRepository<Ordering> repository)
    : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
{
    public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
    {
        var values = await repository.GetAllAsync();
        return values.Select(x => new GetOrderingQueryResult
        {
            UserId = x.UserId,
            OrderDate = x.OrderDate,
            OrderingId = x.OrderingId,
            TotalPrice = x.TotalPrice
        }).ToList();
    }
}