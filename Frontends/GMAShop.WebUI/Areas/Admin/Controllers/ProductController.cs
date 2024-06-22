using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GMAShop.DtoLayer.CatalogDtos.ProductDtos;
using GMAShop.WebUI.Services.CatalogServices.Category;
using GMAShop.WebUI.Services.CatalogServices.Product;


namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        void ProductViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";
            ViewBag.v0 = "Ürün İşlemleri";
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ProductViewBagList();
            var values = await _productService.GetAllProductAsync();
            return View(values);
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList();

            //var client = _httpClientFactory.CreateClient();
            //var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");
            //if (responseMessage.IsSuccessStatusCode)
            //{
            //    var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //    var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //    return View(values);
            //}
            var values = await _productService.GetProductsWithCategoryAsync();
            return View(values);
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBagList();
            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID
                }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }

        [HttpPost]
        [Route("CreateProduct")]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBagList();

            var values = await _categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID
                }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var productValues = await _productService.GetByIdProductAsync(id);
            return View(productValues);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}

#region Old Method

//using GMAShop.DtoLayer.ProductDtos;
// using Microsoft.AspNetCore.Mvc;
// using Newtonsoft.Json;
// using System.Text;
// using GMAShop.DtoLayer.CategoryDtos;
// using Microsoft.AspNetCore.Mvc.Rendering;
//
// namespace GMAShop.WebUI.Areas.Admin.Controllers
// {
//     [Area("Admin")]
//     [Route("Admin/Product")]
//     public class ProductController : Controller
//     {
//         private readonly IHttpClientFactory _httpClientFactory;
//         protected string _url => "https://localhost:7070/api/Products";
//         public ProductController(IHttpClientFactory httpClientFactory)
//         {
//             _httpClientFactory = httpClientFactory;
//         }
//
//         [Route("Index")]
//         public async Task<IActionResult> Index()
//         {
//             ViewBag.v1 = "Anasayfa";
//             ViewBag.v2 = "Ürünler";
//             ViewBag.v3 = "Ürün listesi";
//             ViewBag.v4 = "Ürün işlemleri";
//
//             var client = _httpClientFactory.CreateClient();
//             var responseMessage = await client.GetAsync(_url);
//
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 var jsonData = await responseMessage.Content.ReadAsStringAsync();
//                 var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
//
//
//                 return View(values);
//             }
//             return View();
//         }
//
//
//         [Route("ProductListWithCategory")]
//         public async Task<IActionResult> ProductListWithCategory()
//         {
//             ViewBag.v1 = "Anasayfa";
//             ViewBag.v2 = "Ürünler";
//             ViewBag.v3 = "Ürün listesi";
//             ViewBag.v4 = "Ürün işlemleri";
//
//             var client = _httpClientFactory.CreateClient();
//             var responseMessage = await client.GetAsync(_url + "/ProductListWithCategory");
//
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 var jsonData = await responseMessage.Content.ReadAsStringAsync();
//                 var values = JsonConvert.DeserializeObject<List<ResultProductsWithCategoryDto>>(jsonData);
//
//
//                 return View(values);
//             }
//             return View();
//         }
//
//         [HttpGet]
//         [Route("CreateProduct")]
//         public async Task<IActionResult> CreateProduct()
//         {
//             ViewBag.v1 = "Anasayfa";
//             ViewBag.v2 = "Ürünler";
//             ViewBag.v3 = "Yeni Ürün Girişi";
//             ViewBag.v4 = "Ürün işlemleri";
//
//
//             var categoryValues = await GetCategories();
//
//             ViewBag.Categories = categoryValues;
//
//
//             return View();
//         }
//
//         private async Task<List<SelectListItem>> GetCategories()
//         {
//             var client = _httpClientFactory.CreateClient();
//             var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
//             var jsonData = await responseMessage.Content.ReadAsStringAsync();
//             var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
//
//             List<SelectListItem> categoryValues = (from c in values
//                                                    select new SelectListItem
//                                                    {
//                                                        Text = c.CategoryName,
//                                                        Value = c.CategoryId
//                                                    }).ToList();
//             return categoryValues;
//         }
//
//         [HttpPost]
//         [Route("CreateProduct")]
//         public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
//         {
//
//             var client = _httpClientFactory.CreateClient();
//             var jsonData = JsonConvert.SerializeObject(createProductDto);
//             StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//
//             var responseMessage = await client.PostAsync(_url, stringContent);
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 return RedirectToAction("Index");
//             }
//             return View();
//         }
//
//         [Route("DeleteProduct/{id}")]
//         public async Task<IActionResult> DeleteProduct(string id)
//         {
//             var client = _httpClientFactory.CreateClient();
//             var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Products?id=" + id);
//
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 return RedirectToAction("Index");
//             }
//
//             return View("Index");
//         }
//
//
//         [Route("UpdateProduct/{id}")]
//         [HttpGet]
//         public async Task<IActionResult> UpdateProduct(string id)
//         {
//             ViewBag.v1 = "Anasayfa";
//             ViewBag.v2 = "Ürünler";
//             ViewBag.v3 = " ürün Güncelleme Sayfası";
//             ViewBag.v4 = "Ürün işlemleri";
//
//             var categoryValues = await GetCategories();
//             ViewBag.Categories = categoryValues;
//
//             var client = _httpClientFactory.CreateClient();
//             var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/" + id);
//
//
//             if (responseMessage.IsSuccessStatusCode)
//             {
//                 var jsonData = await responseMessage.Content.ReadAsStringAsync();
//                 var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
//                 return View(values);
//             }
//
//             return View();
//         }
//
//         [Route("UpdateProduct/{id}")]
//         [HttpPost]
//         public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
//         {
//
//             var client = _httpClientFactory.CreateClient();
//             var jsonData = JsonConvert.SerializeObject(updateProductDto);
//             StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
//
//             var responseMessage = await client.PutAsync("https://localhost:7070/api/Products/", stringContent);
//
//             if (responseMessage.IsSuccessStatusCode)
//             {
//
//                 return RedirectToAction("Index");
//             }
//
//             return View();
//         }
//     }
// }

#endregion