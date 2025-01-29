using Microsoft.AspNetCore.Mvc;
using GMAShop.DtoLayer.BasketDtos;
using GMAShop.WebUI.Services.BasketServices;
using GMAShop.WebUI.Services.CatalogServices.ProductServices;

namespace GMAShop.WebUI.Controllers
{
    public class ShoppingCartController(IProductService productService, IBasketService basketService)
        : Controller
    {
        public async Task<IActionResult> Index()
        {
            var values = await basketService.GetBasket();
            return View(values);
        }

        public async Task<IActionResult> AddBasketItem(string productId)
        {
            var values = await productService.GetByIdProductAsync(productId);
            var items = new BasketItemDto()
            {
                ProductId = values.ProductId,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                ProductImageUrl = values.ProductImageUrl,
                Quantity = 1
            };
            await basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string productId)
        {
            await basketService.RemoveBasketItem(productId);
            return RedirectToAction("Index");
        }
    }
}

#region old way

// public async Task<IActionResult> Index(string code,int discountRate,decimal totalNewPriceWithDiscount)
// {
//     ViewBag.code = code;
//     ViewBag.discountRate = discountRate;
//     ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
//     ViewBag.directory1 = "Ana Sayfa";
//     ViewBag.directory2 = "Ürünler";
//     ViewBag.directory3 = "Sepetim";
//     var values = await basketService.GetBasket();
//     ViewBag.total = values.TotalPrice;
//     var totalPriceWithTax = values.TotalPrice + values.TotalPrice / 100 * 10;
//     var tax = values.TotalPrice / 100 * 10;
//     ViewBag.totalPriceWithTax = totalPriceWithTax;
//     ViewBag.tax = tax;
//     return View();
// }
//
// //[HttpPost]
// public async Task<IActionResult> AddBasketItem(string id)
// {
//     var values = await productService.GetByIdProductAsync(id);
//     var items = new BasketItemDto
//     {
//         ProductId = values.ProductId,
//         ProductName = values.ProductName,
//         Price = values.ProductPrice,
//         Quantity = 1,
//         ProductImageUrl = values.ProductImageUrl
//     };
//     await basketService.AddBasketItem(items);
//     return RedirectToAction("Index");
// }
//
// public async Task<IActionResult> RemoveBasketItem(string id)
// {
//     await basketService.RemoveBasketItem(id);
//     return RedirectToAction("Index");
// }

#endregion