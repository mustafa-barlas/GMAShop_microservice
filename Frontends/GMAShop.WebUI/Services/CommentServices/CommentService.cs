using GMAShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;

namespace GMAShop.WebUI.Services.CommentServices
{
    public class CommentService(HttpClient httpClient) : ICommentService
    {
        public async Task CreateCommentAsync(CreateCommentDto createCommentDto)
        {
            await httpClient.PostAsJsonAsync<CreateCommentDto>("comments", createCommentDto);
        }
        public async Task DeleteCommentAsync(string id)
        {
            await httpClient.DeleteAsync("comments?id=" + id);
        }
        public async Task<UpdateCommentDto> GetByIdCommentAsync(string id)
        {
            var responseMessage = await httpClient.GetAsync("comments/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateCommentDto>();
            return values;
        }
        public async Task<List<ResultCommentDto>> GetAllCommentAsync()
        {
            var responseMessage = await httpClient.GetAsync("comments");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return values;
        }
        public async Task UpdateCommentAsync(UpdateCommentDto updateCommentDto)
        {
            await httpClient.PutAsJsonAsync<UpdateCommentDto>("comments", updateCommentDto);
        }
        public async Task<List<ResultCommentDto>> CommentListByProductId(string id)
        {
            var responseMessage = await httpClient.GetAsync($"comments/CommentListByProductId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
            return values;
        }

        public async Task<int> GetTotalCommentCount()
        {
            var responseMessage = await httpClient.GetAsync("comments/GetTotalCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetActiveCommentCount()
        {
            var responseMessage = await httpClient.GetAsync("comments/GetActiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }

        public async Task<int> GetPAssiveCommentCount()
        {
            var responseMessage = await httpClient.GetAsync("comments/GetPassiveCommentCount");
            var values = await responseMessage.Content.ReadFromJsonAsync<int>();
            return values;
        }
    }
}
