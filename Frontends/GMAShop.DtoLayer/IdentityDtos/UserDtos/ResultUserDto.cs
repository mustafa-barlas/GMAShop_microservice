namespace GMAShop.DtoLayer.IdentityDtos.UserDtos
{
    public record ResultUserDto
    {
        public string name { get; init; }
        public string surname { get; init; }
        public string id { get; init; }
        public string userName { get; init; }
        public string normalizedUserName { get; init; }
        public string email { get; init; }
        public string normalizedEmail { get; init; }
        public bool emailConfirmed { get; init; }
        public string passwordHash { get; init; }
        public string securityStamp { get; init; }
        public string concurrencyStamp { get; init; }
        public object phoneNumber { get; init; }
        public bool phoneNumberConfirmed { get; init; }
        public bool twoFactorEnabled { get; init; }
        public object lockoutEnd { get; init; }
        public bool lockoutEnabled { get; init; }
        public int accessFailedCount { get; init; }
    }

}