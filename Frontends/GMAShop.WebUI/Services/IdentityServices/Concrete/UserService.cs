using GMAShop.WebUI.Models;
using GMAShop.WebUI.Services.IdentityServices.Abstract;

namespace GMAShop.WebUI.Services.IdentityServices.Concrete
{
    public class UserService(HttpClient httpClient) : IUserService
    {
        public async Task<UserDetailViewModel?> GetUserInfo()
        {
            return await httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }
    }
}