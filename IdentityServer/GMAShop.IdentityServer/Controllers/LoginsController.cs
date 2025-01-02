using System.Threading.Tasks;
using GMAShop.IdentityServer.Dtos;
using GMAShop.IdentityServer.Models;
using GMAShop.IdentityServer.Tools;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.IdentityServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginsController(SignInManager<ApplicationUser> signInManager,UserManager<ApplicationUser> userManager) : Controller
{
    [HttpPost]
    public async Task<IActionResult> UserLogin(UserLoginDto userLoginDto)
    {
         var result = await signInManager.PasswordSignInAsync
             (userLoginDto.UserName, userLoginDto.Password, false, false);

         var user = await userManager.FindByNameAsync(userLoginDto.UserName);
         if (result.Succeeded)
         {
             GetCheckAppUserViewModel model = new()
             {
                 UserName = userLoginDto.UserName,
                 Id = user.Id
             };
             var token = JwtTokenGenerator.GenerateToken(model);
                 return Ok(token);
         }
         else
         {
             return BadRequest("Invalid username or password");
         }
        // return result.Succeeded ? Ok("Giriş başarılı") : Ok("kullanıcı adı veya şifre hatalı");
    }
}