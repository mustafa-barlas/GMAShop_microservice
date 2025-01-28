namespace GMAShop.DtoLayer.IdentityDtos.LoginDtos
{
    public record SignInDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
