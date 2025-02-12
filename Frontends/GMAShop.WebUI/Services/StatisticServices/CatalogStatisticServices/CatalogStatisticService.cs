
namespace GMAShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public class CatalogStatisticService(HttpClient httpClient) : ICatalogStatisticService
    {
        public async Task<long> GetBrandCount()
        {
            var responseMessage = await httpClient.GetAsync("Statistics/GetBrandCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<long> GetCategoryCount()
        {
            var responseMessage = await httpClient.GetAsync("Statistics/GetCategoryCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }

        public async Task<string> GetMaxPriceProductName()
        {
            var responseMessage = await httpClient.GetAsync("Statistics/GetMaxPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<string> GetMinPriceProductName()
        {
            var responseMessage = await httpClient.GetAsync("Statistics/GetMinPriceProductName");
            var values = await responseMessage.Content.ReadAsStringAsync();
            return values;
        }

        public async Task<decimal> GetProductAvgPrice()
        {
            var responseMessage = await httpClient.GetAsync("Statistics/GetProductAvgPrice");
            var values = await responseMessage.Content.ReadFromJsonAsync<decimal>();
            return values;
        }

        public async Task<long> GetProductCount()
        {
            var responseMessage = await httpClient.GetAsync("Statistics/GetProductCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<long>();
            return values;
        }
    }
}
