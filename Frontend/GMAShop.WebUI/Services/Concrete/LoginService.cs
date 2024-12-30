using System.Security.Claims;
using GMAShop.WebUI.Services.Interfaces;

namespace GMAShop.WebUI.Services.Concrete
{
    public class LoginService : ILoginService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public LoginService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
