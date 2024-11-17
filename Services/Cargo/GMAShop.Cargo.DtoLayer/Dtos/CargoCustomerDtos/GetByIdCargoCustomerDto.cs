using GMAShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using GMAShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;

namespace GMAShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;

public class GetByIdCargoCustomerDto
{
    public int CargoCustomerId { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Address { get; set; }

    // İlişkili Kargo Detayları
    public List<GetAllCargoDetailDto> CargoDetails { get; set; }

}