using System.Linq;
using GMAShop.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.IdentityServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StatisticsController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    public StatisticsController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult GetUserCount()
    {
        int usercount = _userManager.Users.Count();
        return Ok(usercount);
    }
}
