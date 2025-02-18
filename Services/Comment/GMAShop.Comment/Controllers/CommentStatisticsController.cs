using GMAShop.Comment.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GMAShop.Comment.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class CommentStatisticsController(CommentContext commentContext) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCommentCount()
    {
        int values = await commentContext.UserComments.CountAsync();
        return Ok(values);
    }
}