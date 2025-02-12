using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.CommentServices;
using GMAShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using GMAShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using GMAShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using GMAShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace GMAShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController(
        ICatalogStatisticService catalogStatisticService,
        IUserStatisticService userStatisticService,
        ICommentService commentService,
        IDiscountStatisticService discountStatisticService,
        IMessageStatisticService messageStatisticService)
        : Controller
    {
        public async Task<IActionResult> Index()
        {
            var getBrandCount = await catalogStatisticService.GetBrandCount();
            var getProductCount = await catalogStatisticService.GetProductCount();
            var getCategoryCount = await catalogStatisticService.GetCategoryCount();
            var getMaxPriceProductName = await catalogStatisticService.GetMaxPriceProductName();
            var getMinPriceProductName = await catalogStatisticService.GetMinPriceProductName();

            var getUserCount = await userStatisticService.GetUsercount();

            var getTotalCommentCount = await commentService.GetTotalCommentCount();
            var getActiveCommentCount = await commentService.GetActiveCommentCount();
            var getPassiveCommentCount = await commentService.GetPAssiveCommentCount();

            var getDiscountCouponCount = await discountStatisticService.GetDiscountCouponCount();

            var getMessageTotalCount = await messageStatisticService.GetTotalMessageCount();

            ViewBag.getBrandCount = getBrandCount;
            ViewBag.getProductCount = getProductCount;
            ViewBag.getCategoryCount = getCategoryCount;
            ViewBag.getMaxPriceProductName = getMaxPriceProductName;
            ViewBag.getMinPriceProductName = getMinPriceProductName;

            ViewBag.getUserCount = getUserCount;

            ViewBag.getTotalCommentCount = getTotalCommentCount;
            ViewBag.getActiveCommentCount = getActiveCommentCount;
            ViewBag.getPassiveCommentCount = getPassiveCommentCount;

            ViewBag.getDiscountCouponCount = getDiscountCouponCount;

            ViewBag.getMessageTotalCount = getMessageTotalCount;

            return View();
        }
    }
}