using GMAShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace GMAShop.WebUI.Services.CatalogServices.ProductServices
{
    public class ProductService(HttpClient httpClient) : IProductService
    {
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            await httpClient.PostAsJsonAsync<CreateProductDto>("products", createProductDto);
        }
        public async Task DeleteProductAsync(string id)
        {
            await httpClient.DeleteAsync("products?id=" + id);
        }
        public async Task<ResultProductDto> GetByIdProductAsync(string id)
        {
            var responseMessage = await httpClient.GetAsync("products/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<ResultProductDto>();
            return values;
        }
        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var responseMessage = await httpClient.GetAsync("products");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return values;
        }
        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            await httpClient.PutAsJsonAsync<UpdateProductDto>("products", updateProductDto);
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var responseMessage = await httpClient.GetAsync("products/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }

        public async Task<List<ResultProductWithCategoryDto>> GetProductsWithCategoryByCatetegoryIdAsync(string CategoryId)
        {
            var responseMessage = await httpClient.GetAsync($"products/ProductListWithCategoryByCategoryId/{CategoryId}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            return values;
        }
    }
}