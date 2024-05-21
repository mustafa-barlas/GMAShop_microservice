using GMAShop.Catalog.Dtos.ProductDetailDtos;
using GMAShop.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var value = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Successful");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Successful");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Successful");
        }
    }
}
