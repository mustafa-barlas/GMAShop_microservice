namespace GMAShop.Cargo.Entities.Concrete;

public class CargoDetail
{
    public int CargoDetailId { get; set; }
    public string SenderCustomer { get; set; }
    public string ReceiverCustomer { get; set; }
    public string Barcode { get; set; }

    public int CustomerId { get; set; }
    public CargoCustomer Customer { get; set; }

    public int CompanyId { get; set; }
    public CargoCompany Company { get; set; }

    public ICollection<CargoOperation> CargoOperations { get; set; }
}