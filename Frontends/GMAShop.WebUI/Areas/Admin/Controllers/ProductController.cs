﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GMAShop.DtoLayer.CatalogDtos.ProductDtos;
using GMAShop.WebUI.Services.CatalogServices.CategoryServices;
using GMAShop.WebUI.Services.CatalogServices.ProductServices;
using Microsoft.AspNetCore.Authorization;

namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Product")]
    [Authorize]

    public class ProductController(IProductService productService, ICategoryService categoryService)
        : Controller
    {
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
            var values = await productService.GetAllProductAsync();
            return View(values);
        }

        [Route("ProductListWithCategory")]
        public async Task<IActionResult> ProductListWithCategory()
        {
            ProductViewBagList();

            var values = await productService.GetProductsWithCategoryAsync();
            return View(values);
            
            // var client = _httpClientFactory.CreateClient();
            // var responseMessage = await client.GetAsync("https://localhost:7070/api/Products/ProductListWithCategory");
            // if (responseMessage.IsSuccessStatusCode)
            // {
            //     var jsonData = await responseMessage.Content.ReadAsStringAsync();
            //     var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
            //     return View(values);
            // }
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ProductViewBagList();
            var values = await categoryService.GetAllCategoryAsync();
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
            await productService.CreateProductAsync(createProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("DeleteProduct/{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProductAsync(id);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }

        [Route("UpdateProduct/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ProductViewBagList();

            var values = await categoryService.GetAllCategoryAsync();
            List<SelectListItem> categoryValues = (from x in values
                select new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryID
                }).ToList();
            ViewBag.CategoryValues = categoryValues;

            var productValues = await productService.GetByIdProductAsync(id);
            return View(productValues);
        }

        [Route("UpdateProduct/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await productService.UpdateProductAsync(updateProductDto);
            return RedirectToAction("Index", "Product", new { area = "Admin" });
        }
    }
}