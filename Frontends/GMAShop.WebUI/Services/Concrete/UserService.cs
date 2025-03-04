using GMAShop.WebUI.Models;
using GMAShop.WebUI.Services.Interfaces;

namespace GMAShop.WebUI.Services.Concrete
{
    public class UserService(HttpClient httpClient) : IUserService
    {
        public async Task<UserDetailViewModel> GetUserInfo()
        {
            return await httpClient.GetFromJsonAsync<UserDetailViewModel>("/api/users/getuser");
        }


        public async Task<List<UserDetailViewModel>> GetAllUsers()
        {
            var values = await httpClient.GetFromJsonAsync<List<UserDetailViewModel>>("/api/users/GetAllUserList");

            return values;
        }
    }
}