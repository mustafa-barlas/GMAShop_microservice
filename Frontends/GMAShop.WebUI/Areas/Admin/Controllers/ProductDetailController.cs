using GMAShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using GMAShop.WebUI.Services.CatalogServices.ProductDetail;
using Microsoft.AspNetCore.Mvc;


namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController(IProductDetailService productDetailService) : Controller
    {
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductDetailViewbagList();
            var values = await productDetailService.GetAllProductDetailAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateProductDetail")]
        public IActionResult CreateProductDetail()
        {
            ProductDetailViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateProductDetail")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
        }

        [Route("DeleteProductDetail/{id}")]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await productDetailService.DeleteProductDetailAsync(id);
            return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
        }

        [Route("UpdateProductDetail/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProductDetail(string id)
        {
            ProductDetailViewbagList();
            var values = await productDetailService.GetByIdProductDetailAsync(id);
            return View(values);
        }
        [Route("UpdateProductDetail/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return RedirectToAction("Index", "ProductDetail", new { area = "Admin" });
        }

        void ProductDetailViewbagList()
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
// using GMAShop.DtoLayer.CatalogDtos.ProductDetailDtos;
// using Newtonsoft.Json;
// using System.Text;
//
// namespace GMAShop.WebUI.Areas.Admin.Controllers
// {
//     [Area("Admin")]
//     [AllowAnonymous]
//     [Route("Admin/ProductDetail")]
//     public class ProductDetailController(IHttpClientFactory httpClientFactory) : Controller
//     {
//         [Route("UpdateProductDetail/{id}")]
//         [HttpGet]
//         public async Task<IActionResult> UpdateProductDetail(string id)
//         {
//             ViewBag.v1 = "Ana Sayfa";
//             ViewBag.v2 = "Ürünler";
//             ViewBag.v3 = "Ürün Açıklama ve Bilgi Güncelleme Sayfası";
//             ViewBag.v0 = "Ürün İşlemleri";
//             var client = httpClientFactory.CreateClient();
//             var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductDetails/GetProductDetailByProductId?id=" + id);
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 var jsonData = await responseMessage.Content.ReadAsStringAsync();
//                 var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
//                 return View(values);
//             }
//             return View();
//         }
//         [Route("UpdateProductDetail/{id}")]
//         [HttpPost]
//         public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
//         {
//
//             var client = httpClientFactory.CreateClient();
//             var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
//             StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//             var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductDetails/", stringContent);
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 return RedirectToAction("ProductListWithCategory", "Product", new { area = "Admin" });
//             }
//             return View();
//         }
//     }
// }
