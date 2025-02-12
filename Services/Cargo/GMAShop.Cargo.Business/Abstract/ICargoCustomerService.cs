using GMAShop.Cargo.Entities.Concrete;

namespace GMAShop.Cargo.Business.Abstract;

public interface ICargoCustomerService : IGenericService<CargoCustomer>
{
    CargoCustomer GetCargoCustomerByUserId(string userId);

}