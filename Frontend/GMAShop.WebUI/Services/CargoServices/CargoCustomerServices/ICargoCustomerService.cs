using GMAShop.DtoLayer.CargoDtos.CargoCustomerDtos;

namespace GMAShop.WebUI.Services.CargoServices.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByIdDto> GetByIdCargoCustomerInfoAsync(string id);
    }
}
