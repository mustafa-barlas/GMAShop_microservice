using System.Threading.Tasks;
using GMAShop.IdentityServer.Dtos;
using GMAShop.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.IdentityServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginsController : Controller
{

    private readonly SignInManager<ApplicationUser> _signInManager;

    public LoginsController(SignInManager<ApplicationUser> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpPost]
    public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
    {
         var result = await _signInManager.PasswordSignInAsync
             (userLoginDto.UserName, userLoginDto.Password, false, false);
        return result.Succeeded ? Ok("Giriş başarılı") : Ok("kullanıcı adı veya şifre hatalı");
    }
}