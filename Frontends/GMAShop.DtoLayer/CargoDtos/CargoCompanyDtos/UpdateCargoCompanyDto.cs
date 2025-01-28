namespace GMAShop.DtoLayer.CargoDtos.CargoCompanyDtos
{
    public record UpdateCargoCompanyDto
    {
        public int cargoCompanyId { get; init; }
        public string cargoCompanyName { get; init; }
    }
}
