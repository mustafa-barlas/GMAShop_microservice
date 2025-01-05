using System.Linq;
using GMAShop.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.IdentityServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController(UserManager<ApplicationUser> userManager) : ControllerBase
{
    [HttpGet]
    public IActionResult GetUserCount()
    {
        int userCount = userManager.Users.Count();
        return Ok(userCount);
    }
}