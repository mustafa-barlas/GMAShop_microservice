using Newtonsoft.Json;

namespace GMAShop.WebUI.Services.StatisticServices.UserStatisticServices
{
    public class UserStatisticService(HttpClient httpClient) : IUserStatisticService
    {
        public async Task<int> GetUsercount()
        {
            var responseMessage = await httpClient.GetAsync("http://localhost:5001/Api/Statistics");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<int>(jsonData);
            return values;
        }
    }
}
