using GMAShop.DtoLayer.CatalogDtos.ProductImageDtos;
using GMAShop.WebUI.Services.CatalogServices.ProductImage;
using Microsoft.AspNetCore.Mvc;


namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController(IProductImageService productImageService) : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductImageViewbagList();
            var values = await productImageService.GetAllProductImageAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateProductImage")]
        public IActionResult CreateProductImage()
        {
            ProductImageViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateProductImage")]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await productImageService.CreateProductImageAsync(createProductImageDto);
            return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
        }

        [Route("DeleteProductImage/{id}")]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await productImageService.DeleteProductImageAsync(id);
            return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
        }

        [Route("UpdateProductImage/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductImage(string id)
        {
            ProductImageViewbagList();
            var values = await productImageService.GetByIdProductImageAsync(id);
            return View(values);
        }
        [Route("UpdateProductImage/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await productImageService.UpdateProductImageAsync(updateProductImageDto);
            return RedirectToAction("Index", "ProductImage", new { area = "Admin" });
        }

        void ProductImageViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Hakkımda";
            ViewBag.v3 = "Hakkımda Listesi";
            ViewBag.v0 = "Hakkımda İşlemleri";
        }
    }
}













// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;
// using GMAShop.DtoLayer.CatalogDtos.ProductImageDtos;
// using Newtonsoft.Json;
// using System.Text;
//
// namespace GMAShop.WebUI.Areas.Admin.Controllers
// {
//     [Area("Admin")]
//     [AllowAnonymous]
//     [Route("Admin/ProductImage")]
//     public class ProductImageController(IHttpClientFactory httpClientFactory) : Controller
//     {
//         [Route("ProductImageDetail/{id}")]
//         [HttpGet]
//         public async Task<IActionResult> ProductImageDetail(string id)
//         {
//             ViewBag.v1 = "Ana Sayfa";
//             ViewBag.v2 = "Ürünler";
//             ViewBag.v3 = "Ürün Görsel Güncelleme Sayfası";
//             ViewBag.v0 = "Ürün Görsel İşlemleri";
//             var client = httpClientFactory.CreateClient();
//             var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductImages/ProductImagesByProductId?id=" + id);
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 var jsonData = await responseMessage.Content.ReadAsStringAsync();
//                 var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
//                 return View(values);
//             }
//             return View();
//         }
//         [Route("ProductImageDetail/{id}")]
//         [HttpPost]
//         public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateProductImageDto)
//         {
//             var client = httpClientFactory.CreateClient();
//             var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
//             StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//             var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductImages", stringContent);
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
//             }
//             return View();
//         }
//     }
// }
