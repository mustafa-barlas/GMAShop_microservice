using GMAShop.Cargo.DataAccess.Abstract;
using GMAShop.Cargo.DataAccess.Concrete.Context;
using GMAShop.Cargo.DataAccess.Repositories;
using GMAShop.Cargo.Entities.Concrete;

namespace GMAShop.Cargo.DataAccess.Concrete.EntityFramework;

public class EfCargoCustomerDal(CargoContextDb cargoContextDb)
    : GenericRepository<CargoCustomer>(cargoContextDb), ICargoCustomerDal
{
    private readonly CargoContextDb _cargoContextDb = cargoContextDb;

    public CargoCustomer GetCargoCustomerByUserId(string userId)
    {
        var value = _cargoContextDb.CargoCustomers.FirstOrDefault(x => x.UserCustomerId == userId);
        return value;
    }
}