using System.Linq;
using System.Threading.Tasks;
using GMAShop.IdentityServer.Models;
using IdentityServer4;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;

namespace GMAShop.IdentityServer.Controllers;

[Authorize(IdentityServerConstants.LocalApi.PolicyName)]

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserManager<ApplicationUser> _userManager;
    public UsersController(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet("GetUser")]
    public async Task<IActionResult> GetUser()
    {
        var userClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
        var user = await _userManager.FindByIdAsync(userClaim.Value);
        return Ok(new
        {
            Id = user.Id,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,
            UserName = user.UserName
        });
    }

    [HttpGet("GetAllUserList")]
    public async Task<IActionResult> GetAllUserList()
    {
        var users = await _userManager.Users.ToListAsync();
        return Ok(users);
    }
}