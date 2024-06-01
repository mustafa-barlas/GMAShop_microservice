using GMAShop.Cargo.DataAccess.Abstract;
using GMAShop.Cargo.DataAccess.Concrete.Context;

namespace GMAShop.Cargo.DataAccess.Repositories;

public class GenericRepository<T>(CargoContextDb cargoContext) : IGenericDal<T> where T : class
{
    private readonly CargoContextDb _cargoContext = cargoContext;

    public void Insert(T entity)
    {
        _cargoContext.Set<T>().Add(entity);
        _cargoContext.SaveChanges();
    }

    public void Update(T entity)
    {
        _cargoContext.Set<T>().Update(entity);
        _cargoContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var value = _cargoContext.Set<T>().Find(id);
        _cargoContext.Set<T>().Remove(value);
        _cargoContext.SaveChanges();
    }

    public T GetById(int id)
    {
        return _cargoContext.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return _cargoContext.Set<T>().ToList();
    }
}