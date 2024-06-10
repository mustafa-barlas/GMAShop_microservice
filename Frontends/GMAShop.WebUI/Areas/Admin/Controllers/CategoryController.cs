using GMAShop.DtoLayer.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(IHttpClientFactory httpClientFactory) : Controller
    {
        public async Task<IActionResult> CategoryList()
        {
            ViewBag.v0 = "Anasayfa";
            ViewBag.v1 = "Kategoriler";
            ViewBag.v2 = "Kategori Listesi";
            ViewBag.v3 = "Kategori İşlemleri";

            //var client = httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            //var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            return View();
        }
    }
}
