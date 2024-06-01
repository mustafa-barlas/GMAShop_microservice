using GMAShop.Cargo.Business.Abstract;
using GMAShop.Cargo.DataAccess.Abstract;
using GMAShop.Cargo.Entities.Concrete;

namespace GMAShop.Cargo.Business.Concrete;

public class CargoCompanyManager(ICargoCompanyDal cargoCompanyDal) : ICargoCompanyService
{
    private readonly ICargoCompanyDal _cargoCompanyDal = cargoCompanyDal;

    public void TInsert(CargoCompany entity)
    {
        _cargoCompanyDal.Insert(entity);
    }

    public void TUpdate(CargoCompany entity)
    {
        _cargoCompanyDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoCompanyDal.Delete(id);
    }

    public CargoCompany TGetById(int id)
    {
        return _cargoCompanyDal.GetById(id);
    }

    public List<CargoCompany> TGetAll()
    {
        return _cargoCompanyDal.GetAll();
    }
}