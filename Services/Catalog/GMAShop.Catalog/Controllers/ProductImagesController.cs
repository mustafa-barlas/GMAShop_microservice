using GMAShop.Catalog.Dtos.ProductImageDtos;
using GMAShop.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImageImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }


        [HttpGet]
        public async Task<IActionResult> GetProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var value = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Successful");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Successful");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Successful");
        }
    }
}
