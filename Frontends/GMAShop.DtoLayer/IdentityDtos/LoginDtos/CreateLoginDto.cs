namespace GMAShop.DtoLayer.IdentityDtos.LoginDtos
{
    public record CreateLoginDto
    {
        public string Username { get; init; }
        public string Password { get; init; }
    }
}
