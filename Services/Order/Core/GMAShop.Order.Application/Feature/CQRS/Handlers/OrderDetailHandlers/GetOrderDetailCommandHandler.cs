using GMAShop.Order.Application.Feature.CQRS.Results.OrderDetailResult;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailCommandHandler
{
    private readonly IRepository<OrderDetail> _repository;

    public GetOrderDetailCommandHandler(IRepository<OrderDetail> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetOrderDetailQueryResult>> Handle()
    {
        var values = await _repository.GetAllAsync();

        return values.Select(x => new GetOrderDetailQueryResult
        {
            OrderDetailId = x.OrderDetailId,
            ProductAmount = x.ProductAmount,
            ProductName = x.ProductName,
            OrderingId = x.OrderingId,
            ProductId = x.ProductId,
            ProductPrice = x.ProductPrice,
            ProductTotalPrice = x.ProductTotalPrice
        }).ToList();
    }
}