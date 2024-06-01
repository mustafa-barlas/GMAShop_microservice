using GMAShop.Cargo.Business.Abstract;
using GMAShop.Cargo.DataAccess.Abstract;
using GMAShop.Cargo.Entities.Concrete;

namespace GMAShop.Cargo.Business.Concrete;

public class CargoOperationManager(ICargoOperationDal cargoOperationDal) : ICargoOperationService
{
    private readonly ICargoOperationDal _cargoOperationDal = cargoOperationDal;

    public void TInsert(CargoOperation entity)
    {
        _cargoOperationDal.Insert(entity);
    }

    public void TUpdate(CargoOperation entity)
    {
        _cargoOperationDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoOperationDal.Delete(id);
    }

    public CargoOperation TGetById(int id)
    {
        return _cargoOperationDal.GetById(id);
    }

    public List<CargoOperation> TGetAll()
    {
        return _cargoOperationDal.GetAll();
    }
}