using GMAShop.Cargo.Business.Abstract;
using GMAShop.Cargo.DataAccess.Abstract;
using GMAShop.Cargo.Entities.Concrete;

namespace GMAShop.Cargo.Business.Concrete;

public class CargoDetailManager(ICargoDetailDal cargoDetailDal) : ICargoDetailService
{
    private readonly ICargoDetailDal _cargoDetailDal = cargoDetailDal;

    public void TInsert(CargoDetail entity)
    {
        _cargoDetailDal.Insert(entity);
    }

    public void TUpdate(CargoDetail entity)
    {
        _cargoDetailDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoDetailDal.Delete(id);
    }

    public CargoDetail TGetById(int id)
    {
        return _cargoDetailDal.GetById(id);
    }

    public List<CargoDetail> TGetAll()
    {
        return _cargoDetailDal.GetAll();
    }
}