using GMAShop.Discount.Dtos;
using GMAShop.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController(IDiscountService discountService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> DiscountCouponList()
        {
            var values = await discountService.GetAllDiscountCouponAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await discountService.GetByIdDiscountCouponAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
            await discountService.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Successful");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateCouponDto)
        {
            await discountService.UpdateDiscountCouponAsync(updateCouponDto);
            return Ok("Successful");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await discountService.DeleteDiscountCouponAsync(id);
            return Ok("Successful");
        }

        [HttpGet("GetCodeDetailByCodeAsync")]
        public async Task<IActionResult> GetCodeDetailByCodeAsync(string code)
        {
            var values = await discountService.GetCodeDetailByCodeAsync(code);
            return Ok(values);
        }
        
        [HttpGet("GetDiscountCouponCountRate")]
        public  IActionResult GetDiscountCouponCountRate(string code)
        {
            var values =  discountService.GetDiscountCouponCountRate(code);
            return Ok(values);
        }
    }
}