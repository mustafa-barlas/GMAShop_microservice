namespace GMAShop.Basket.LoginServices;

public class LoginService : ILoginService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string UserId
    {
        get
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null || httpContext.User == null)
            {
                return null;
            }

            var userIdClaim = httpContext.User.FindFirst("sub");
            return userIdClaim?.Value;
        }
    }
}
