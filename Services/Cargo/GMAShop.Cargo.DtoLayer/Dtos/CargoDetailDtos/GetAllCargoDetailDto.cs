using GMAShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;

namespace GMAShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;

public class GetAllCargoDetailDto
{
    public int CargoDetailId { get; set; }
    public string? SenderCustomer { get; set; }
    public string? ReceiverCustomer { get; set; }
    public string Barcode { get; set; }
    public int CargoCustomerId { get; set; }
    public int CargoCompanyId { get; set; }

    public List<GetAllCargoOperationDto> Operations { get; set; }
}