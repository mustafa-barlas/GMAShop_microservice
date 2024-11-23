using GMAShop.DtoLayer.OrderDtos.OrderOrderingDtos;

namespace GMAShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public interface IOrderOderingService
    {
        Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id);
    }
}
