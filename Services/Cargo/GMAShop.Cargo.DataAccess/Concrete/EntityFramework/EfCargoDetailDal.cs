using GMAShop.Cargo.DataAccess.Abstract;
using GMAShop.Cargo.DataAccess.Concrete.Context;
using GMAShop.Cargo.DataAccess.Repositories;
using GMAShop.Cargo.Entities.Concrete;

namespace GMAShop.Cargo.DataAccess.Concrete.EntityFramework;

public class EfCargoDetailDal(CargoContextDb cargoContextDb)
    : GenericRepository<CargoDetail>(cargoContextDb), ICargoDetailDal
{
}