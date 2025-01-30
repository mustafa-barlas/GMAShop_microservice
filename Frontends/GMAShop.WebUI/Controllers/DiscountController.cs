using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.BasketServices;
using GMAShop.WebUI.Services.DiscountServices;

namespace GMAShop.WebUI.Controllers
{
    public class DiscountController(IDiscountService discountService, IBasketService basketService)
        : Controller
    {
        [HttpGet]
        public PartialViewResult ConfirmDiscountCoupon()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmDiscountCoupon(string code)
        {
            var values = await discountService.GetDiscountCouponCountRate(code);

            var basketValues = await basketService.GetBasket();
            var totalPriceWithTax = basketValues.TotalPrice + basketValues.TotalPrice / 100 * 10;

            var totalNewPriceWithDiscount = totalPriceWithTax - (totalPriceWithTax / 100 * values);
            // ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;

            return RedirectToAction("Index", "ShoppingCart", new { code = code, discountRate = values, totalNewPriceWithDiscount = totalNewPriceWithDiscount });
        }
    }
}
