using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GMAShop.Catalog.Dtos.FeatureSliderDtos;
using GMAShop.Catalog.Services.FeatureSliderServices;

namespace GMAShop.Catalog.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController(IFeatureSliderService featureSliderService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> FeatureSliderList()
        {
            var values = await featureSliderService.GetAllFeatureSliderAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeatureSliderById(string id)
        {
            var values = await featureSliderService.GetByIdFeatureSliderAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            await featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            return Ok("Öne çıkan görsel başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            await featureSliderService.DeleteFeatureSliderAsync(id);
            return Ok("Öne çıkan görsel başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            await featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            return Ok("Öne çıkan görsel başarıyla güncellendi");
        }
    }
}