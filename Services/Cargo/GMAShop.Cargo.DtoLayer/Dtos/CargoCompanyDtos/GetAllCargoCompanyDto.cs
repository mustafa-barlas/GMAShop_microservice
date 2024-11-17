using GMAShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;

namespace GMAShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;

public class GetAllCargoCompanyDto
{
    public int CargoCompanyId { get; set; }
    public string? CargoCompanyName { get; set; }
    public List<GetAllCargoDetailDto> CargoDetails { get; set; }
}