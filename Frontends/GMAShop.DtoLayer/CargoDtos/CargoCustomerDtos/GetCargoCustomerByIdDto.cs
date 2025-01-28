namespace GMAShop.DtoLayer.CargoDtos.CargoCustomerDtos
{
    public record GetCargoCustomerByIdDto
    {
        public int cargoCustomerId { get; init; }
        public string name { get; init; }
        public string surname { get; init; }
        public string email { get; init; }
        public string phone { get; init; }
        public string district { get; init; }
        public string city { get; init; }
        public string address { get; init; }
        public string userCustomerId { get; init; }
    }

}