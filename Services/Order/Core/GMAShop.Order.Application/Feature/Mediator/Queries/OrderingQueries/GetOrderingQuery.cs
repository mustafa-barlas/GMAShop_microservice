using GMAShop.Order.Application.Feature.Mediator.Results.OrderingResults;
using MediatR;

namespace GMAShop.Order.Application.Feature.Mediator.Queries.OrderingQueries;

public class GetOrderingQuery : IRequest<List<GetOrderingQueryResult>>
{

}