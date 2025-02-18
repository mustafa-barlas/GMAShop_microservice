using GMAShop.Message.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.Message.Controllers;

[AllowAnonymous]
[Route("api/[controller]")]
[ApiController]
public class UserMessageStatisticsController(IUserMessageService userMessageService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTotalMessageCount()
    {
        int messageCount = await userMessageService.GetTotalMessageCountAsync();
        return Ok(messageCount);
    }
}