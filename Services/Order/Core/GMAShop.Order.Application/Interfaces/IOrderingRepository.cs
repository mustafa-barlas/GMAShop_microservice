using GMAShop.Order.Domain.Entities;

namespace GMAShop.Order.Application.Interfaces;

public interface IOrderingRepository
{
    List<Ordering> GetOrderingsByUserId(string id);
}