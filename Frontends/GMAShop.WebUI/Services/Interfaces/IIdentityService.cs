using GMAShop.DtoLayer.IdentityDtos.LoginDtos;

namespace GMAShop.WebUI.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<bool> SignIn(SignInDto signInDto);
        Task<bool> GetRefreshToken();
    }
}
