using System.Security.Claims;
using GMAShop.WebUI.Services.IdentityServices.Abstract;


namespace GMAShop.WebUI.Services.IdentityServices.Concrete
{
    public class LoginService(IHttpContextAccessor contextAccessor) : ILoginService
    {
        public string GetUserId
        {
            get
            {
                var user = contextAccessor.HttpContext?.User;
                if (user?.Identity?.IsAuthenticated != true)
                {
                    throw new InvalidOperationException("User is not authenticated");
                }

                var userIdClaim = user?.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim is null)
                {
                    throw new InvalidOperationException("User ID claim not found");
                }

                return userIdClaim.Value;
            }
        }
    }
}