using GMAShop.Catalog.Services.StatisticServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController(IStatisticService statisticService) : ControllerBase
    {
        [HttpGet("GetBrandCount")]
        [Authorize]
        public async Task<IActionResult> GetBrandCount()
        {
            var value = await statisticService.GetBrandCount();
            return Ok(value);
        }

        [HttpGet("GetCategoryCount")]
        [Authorize]
        public async Task<IActionResult> GetCategoryCount()
        {
            var value = await statisticService.GetCategoryCount();
            return Ok(value);
        }

        [HttpGet("GetProductCount")]
        [Authorize]
        public async Task<IActionResult> GetProductCount()
        {
            var value = await statisticService.GetProductCount();
            return Ok(value);
        }

        [HttpGet("GetProductAvgPrice")]
        [Authorize]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var value = await statisticService.GetProductAvgPrice();
            return Ok(value);
        }


        [HttpGet("GetMaxPriceProductName")]
        [Authorize]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var value = await statisticService.GetMaxPriceProductName();
            return Ok(value);
        }

        [HttpGet("GetMinPriceProductName")]
        [Authorize]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var value = await statisticService.GetMinPriceProductName();
            return Ok(value);
        }
    }
}