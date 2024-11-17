namespace GMAShop.Cargo.Entities.Concrete;

public class CargoOperation
{
    public int CargoOperationId { get; set; }
    public string Barcode { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public DateTime OperationDate { get; set; }

    public int CargoDetailId { get; set; }
    public CargoDetail CargoDetail { get; set; }
}