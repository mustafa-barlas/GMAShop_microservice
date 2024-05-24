using GMAShop.Order.Application.Feature.CQRS.Queries.OrderDetailQueries;
using GMAShop.Order.Application.Feature.CQRS.Results.OrderDetailResult;
using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Feature.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdCommandHandler
{
    private readonly IRepository<OrderDetail> _addressRepository;

    public GetOrderDetailByIdCommandHandler(IRepository<OrderDetail> addressRepository)
    {
        _addressRepository = addressRepository;
    }


    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery result)
    {
        var values = await _addressRepository.GetByIdAsync(result.Id);
        return new()
        {
            OrderDetailId = values.OrderDetailId,
            ProductPrice = values.ProductPrice,
            ProductTotalPrice = values.ProductTotalPrice,
            ProductName = values.ProductName,
            OrderingId = values.OrderingId,
            ProductAmount = values.ProductAmount,
            ProductId = values.ProductId
        };
    }
}