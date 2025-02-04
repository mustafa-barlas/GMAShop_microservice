using GMAShop.Order.Application.Interfaces;
using GMAShop.Order.Domain.Entities;
using GMAShop.Order.Persistence.Contexts;

namespace GMAShop.Order.Persistence.Repositories;

public class OrderingRepository(OrderContext orderContext) : IOrderingRepository
{
    public List<Ordering> GetOrderingsByUserId(string id)
    {
        var values = orderContext.Orderings.Where(x => x.UserId.Equals(id)).ToList();
        return values;
    }
}