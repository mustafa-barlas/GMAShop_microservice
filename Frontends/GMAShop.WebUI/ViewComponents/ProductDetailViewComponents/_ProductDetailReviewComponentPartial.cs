using Microsoft.AspNetCore.Mvc;
using GMAShop.WebUI.Services.CommentServices;

namespace GMAShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _ProductDetailReviewComponentPartial(ICommentService commentService) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await commentService.CommentListByProductId(id);
            return View(values);
        }
    }
}
