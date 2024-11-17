namespace GMAShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;

public class UpdateCargoDetailDto
{
    public int CargoDetailId { get; set; }
    public string? SenderCustomer { get; set; }
    public string? ReceiverCustomer { get; set; }
    public string Barcode { get; set; }
    public int CargoCustomerId { get; set; }
    public int CargoCompanyId { get; set; }
}