using GMAShop.DtoLayer.IdentityDtos.UserDtos;

namespace GMAShop.WebUI.Services.UserIdentityServices
{
    public interface IUserIdentityService
    {
        Task<List<ResultUserDto>> GetAllUserListAsync();
    }
}
