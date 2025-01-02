using System.Security.Claims;
using GMAShop.WebUI.Services.Interfaces;

namespace GMAShop.WebUI.Services.Concrete
{
    public class LoginService(IHttpContextAccessor contextAccessor) : ILoginService
    {
        public string GetUserId => contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
