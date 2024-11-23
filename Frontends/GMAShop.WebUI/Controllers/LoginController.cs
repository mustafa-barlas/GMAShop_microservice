using GMAShop.DtoLayer.IdentityDtos.LoginDtos;

using GMAShop.WebUI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IIdentityService _identityService;
        public LoginController(IHttpClientFactory httpClientFactory, IIdentityService identityService)
        {
            _httpClientFactory = httpClientFactory;
            _identityService = identityService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SignInDto signInDto)
        {
            await _identityService.SignIn(signInDto);
            return RedirectToAction("Index", "User");
        }
    

    // [HttpPost]
    // public async Task<IActionResult> Index(SignInDto signInDto)
    // {
    //     var client = httpClientFactory.CreateClient();
    //     var content = new StringContent(JsonSerializer.Serialize(signInDto), Encoding.UTF8, "application/json");
    //     var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
    //     if (response.IsSuccessStatusCode)
    //     {
    //         var jsonData = await response.Content.ReadAsStringAsync();
    //         var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
    //         {
    //             PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    //         });
    //
    //         if (tokenModel != null)
    //         {
    //             JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
    //             var token = handler.ReadJwtToken(tokenModel.Token);
    //             var claims = token.Claims.ToList();
    //             if (tokenModel.Token != null)
    //             {
    //                 claims.Add(new Claim("gmashoptoken", tokenModel.Token));
    //                 var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
    //                 var authProps = new AuthenticationProperties
    //                 {
    //                     ExpiresUtc = tokenModel.ExpireDate,
    //                     IsPersistent = true
    //                 };
    //
    //                 await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal
    //                     (claimsIdentity), authProps);
    //                 
    //                 return RedirectToAction("Index", "Default");
    //             }
    //         }
    //     }
    //
    //
    //     return View();
    // }
}
}