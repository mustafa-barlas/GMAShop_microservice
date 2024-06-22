using GMAShop.DtoLayer.IdentityDtos.UserDtos;

namespace GMAShop.WebUI.Services.IdentityServices.Abstract;

public interface IUserIdentityService
{
    Task<List<ResultUserDto>> GetAllUserListAsync();
}