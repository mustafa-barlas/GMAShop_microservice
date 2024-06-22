using GMAShop.WebUI.Models;

namespace GMAShop.WebUI.Services.IdentityServices.Abstract;

public interface IUserService
{
    Task<UserDetailViewModel?> GetUserInfo();
}