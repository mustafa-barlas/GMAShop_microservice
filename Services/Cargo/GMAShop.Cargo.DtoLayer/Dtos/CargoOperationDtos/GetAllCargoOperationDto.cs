namespace GMAShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;

public class GetAllCargoOperationDto
{
    public int CargoOperationId { get; set; }
    public string? Barcode { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; }
    public DateTime OperationDate { get; set; }
    public int CargoDetailId { get; set; }
}