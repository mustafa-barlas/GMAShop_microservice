using GMAShop.Catalog.Dtos.FeatureSliderDtos;
using GMAShop.Catalog.Services.FeatureSliderService;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureSlidersController(IFeatureSliderService featureSliderService) : ControllerBase
    {
        private readonly IFeatureSliderService _featureSliderService = featureSliderService;

        [HttpGet]
            public async Task<IActionResult> GetFeatureSliderList()
            {
                var values = await featureSliderService.GetAllFeatureSliderAsync();
                return Ok(values);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetFeatureSliderById(string id)
            {
                var value = await featureSliderService.GetByIdFeatureSliderAsync(id);
                return Ok(value);
            }

            [HttpPost]
            public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
            {
                await featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
                return Ok("Successful");
            }

            [HttpDelete]
            public async Task<IActionResult> DeleteFeatureSlider(string id)
            {
                await featureSliderService.DeleteFeatureSliderAsync(id);
                return Ok();
            }

            [HttpPut]
            public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
            {
                await featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
                return Ok();
            }
        }
    }

