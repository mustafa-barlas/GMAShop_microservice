﻿using GMAShop.DtoLayer.OrderDtos.OrderOrderingDtos;
using Newtonsoft.Json;

namespace GMAShop.WebUI.Services.OrderServices.OrderOrderingServices
{
    public class OrderOrderingService(HttpClient httpClient) : IOrderOrderingService
    {
        public async Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string id)
        {
            //$"products/ProductListWithCategoryByCategoryId/{CategoryId}"
            var responseMessage = await httpClient.GetAsync($"orderings/GetOrderingByUserId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultOrderingByUserIdDto>>(jsonData);
            return values;
        }
    }
}
