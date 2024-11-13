using MediatR;

namespace GMAShop.Order.Application.Feature.Mediator.Results.OrderingResults;

public class GetOrderingQueryResult : IRequest<List<GetOrderingQueryResult>>
{
    public int OrderingId { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}