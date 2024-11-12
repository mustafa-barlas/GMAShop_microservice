using GMAShop.WebUI.Services.CatalogServices.Category;
using Microsoft.AspNetCore.Mvc;


namespace GMAShop.WebUI.Controllers
{
    public class TestController : Controller
    {

        private readonly ICategoryService _categoryService;

        public TestController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            // string token = "";
            // using (var httpClient = new HttpClient())
            // {
            //     var request = new HttpRequestMessage
            //     {
            //         RequestUri = new Uri("http://localhost:5001/connect/token"),
            //         Method = HttpMethod.Post,
            //         Content = new FormUrlEncodedContent(new Dictionary<string, string>
            //         {
            //             {"client_id","GMAShopVisitorId" },
            //             {"client_secret","gmashopsecret" },
            //             {"grant_type","client_credentials" }
            //         })
            //     };
            //
            //     using (var response = await httpClient.SendAsync(request))
            //     {
            //         if (response.IsSuccessStatusCode)
            //         {
            //             var content = await response.Content.ReadAsStringAsync();
            //             var tokenResponse = JObject.Parse(content);
            //             token = tokenResponse["access_token"].ToString();
            //         }
            //     }
            // }
            //
            // var client = httpClientFactory.CreateClient();
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //
            // var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            // if (responseMessage.IsSuccessStatusCode)
            // {
            //     var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //     var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            //     return View(values);
            // }
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
        public IActionResult Deneme1()
        {
            return View();
        }

        public async Task<ActionResult> Deneme2()
        {
           
            return View();
        }
    }
}