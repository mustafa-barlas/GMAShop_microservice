namespace GMAShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;

public class CreateCargoDetailDto
{
    public string? SenderCustomer { get; set; }
    public string? ReceiverCustomer { get; set; }
    public string Barcode { get; set; }
    public int CargoCustomerId { get; set; } 
    public int CargoCompanyId { get; set; } 
}