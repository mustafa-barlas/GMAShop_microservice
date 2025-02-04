using GMAShop.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace GMAShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetOrderingByUserIdQuery(string userId) : IRequest<List<GetOrderingByUserIdQueryResult>>
{
    public string UserId { get; set; } = userId;
}