using GMAShop.Catalog.Dtos.BrandDtos;
using GMAShop.Catalog.Services.BrandServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController(IBrandService brandService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var values = await brandService.GetAllBrandAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrandById(string id)
        {
            var values = await brandService.GetByIdBrandAsync(id);
            return Ok(values);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            await brandService.CreateBrandAsync(createBrandDto);
            return Ok("Marka başarıyla eklendi");
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            await brandService.DeleteBrandAsync(id);
            return Ok("Marka başarıyla silindi");
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            await brandService.UpdateBrandAsync(updateBrandDto);
            return Ok("Marka başarıyla güncellendi");
        }
    }
}
