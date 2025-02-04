using GMAShop.Order.Application.Features.Mediator.Queries.OrderingQueries;
using GMAShop.Order.Application.Features.Mediator.Results.OrderingResults;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;
using MediatR;

namespace GMAShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByUserIdQueryHandler(IOrderingRepository orderingRepository)
    : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
{
    public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        var values = orderingRepository.GetOrderingsByUserId(request.UserId);

        return values.Select(x => new GetOrderingByUserIdQueryResult
        {
            OrderingId = x.OrderingId,
            OrderDate = x.OrderDate,
            TotalPrice = x.TotalPrice,
            UserId = x.UserId,
        }).ToList();


        // var values = await repository.GetByIdAsync(request);
        // return new GetOrderingByUserIdQueryResult()
        // {
        //     UserId = values.UserId,
        //     OrderDate = values.OrderDate,
        //     OrderingId = values.OrderingId,
        //     TotalPrice = values.TotalPrice
        // };
        //
    }
}