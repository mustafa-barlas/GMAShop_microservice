using GMAShop.Cargo.Business.Abstract;
using GMAShop.Cargo.DataAccess.Abstract;
using GMAShop.Cargo.Entities.Concrete;

namespace GMAShop.Cargo.Business.Concrete;

public class CargoCustomerManager(ICargoCustomerDal cargoCustomerDal) : ICargoCustomerService
{
    private readonly ICargoCustomerDal _cargoCustomerDal = cargoCustomerDal;

    public void TInsert(CargoCustomer entity)
    {
        _cargoCustomerDal.Insert(entity);
    }

    public void TUpdate(CargoCustomer entity)
    {
        _cargoCustomerDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoCustomerDal.Delete(id);
    }

    public CargoCustomer TGetById(int id)
    {
        return _cargoCustomerDal.GetById(id);
    }

    public List<CargoCustomer> TGetAll()
    {
        return _cargoCustomerDal.GetAll();
    }

    public CargoCustomer GetCargoCustomerByUserId(string userId)
    {
        var value = _cargoCustomerDal.GetCargoCustomerByUserId(userId);
        return value;
    }
}