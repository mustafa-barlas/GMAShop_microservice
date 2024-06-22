using System.Net;
using System.Net.Http.Headers;
using GMAShop.WebUI.Services.IdentityServices.Abstract;

namespace GMAShop.WebUI.Handlers;

public class ClientCredentialTokenHandler(IClientCredentialTokenService clientCredentialTokenService)
    : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        request.Headers.Authorization =
            new AuthenticationHeaderValue("Bearer", await clientCredentialTokenService.GetToken());
        var response = await base.SendAsync(request, cancellationToken);
        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            //hata mesajı
        }

        return response;
    }
}