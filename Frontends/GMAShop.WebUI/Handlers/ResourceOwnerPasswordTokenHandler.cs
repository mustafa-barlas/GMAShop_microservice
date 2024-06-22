using System.Net;
using System.Net.Http.Headers;
using GMAShop.WebUI.Services.IdentityServices.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace GMAShop.WebUI.Handlers;

public class ResourceOwnerPasswordTokenHandler(
    IHttpContextAccessor httpContextAccessor,
    IIdentityService identityService)
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var accessToken = await httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.AccessToken);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
        var response = await base.SendAsync(request, cancellationToken);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            var tokenResponse = await identityService.GetRefreshToken();

            if (tokenResponse)
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                response = await base.SendAsync(request, cancellationToken);
            }
        }

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            //hata mesajı
        }

        return response;
    }
}