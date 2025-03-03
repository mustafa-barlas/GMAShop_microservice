using GMAShop.Catalog.Dtos.ProductDetailDtos;
using GMAShop.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController(IProductDetailService productDetailService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = await productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpGet("GetProductDetailByProductId/{id}")]
        public async Task<IActionResult> GetProductDetailByProductId(string id)
        {
            var values = await productDetailService.GetByProductIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün detayı başarıyla eklendi");
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarıyla silindi");
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}