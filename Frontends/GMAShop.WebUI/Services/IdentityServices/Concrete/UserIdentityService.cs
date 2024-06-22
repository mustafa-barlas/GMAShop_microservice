using GMAShop.DtoLayer.IdentityDtos.UserDtos;
using GMAShop.WebUI.Services.IdentityServices.Abstract;
using Newtonsoft.Json;

namespace GMAShop.WebUI.Services.IdentityServices.Concrete;

public class UserIdentityService(HttpClient httpClient) : IUserIdentityService
{
    public async Task<List<ResultUserDto>> GetAllUserListAsync()
    {
        var responseMessage = await httpClient.GetAsync("http://localhost:5001/api/users/GetAllUserList");
        var jsonData = await responseMessage.Content.ReadAsStringAsync();
        var values = JsonConvert.DeserializeObject<List<ResultUserDto>>(jsonData);
        return values;
    }
}