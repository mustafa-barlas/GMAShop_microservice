namespace GMAShop.Cargo.Entities.Concrete;

public class CargoCompany
{
    public int CargoCompanyId { get; set; }
    public string CargoCompanyName { get; set; }

    public ICollection<CargoDetail> CargoDetails { get; set; }
}