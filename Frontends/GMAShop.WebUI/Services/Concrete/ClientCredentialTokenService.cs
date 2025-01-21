using GMAShop.WebUI.Services.Interfaces;
using GMAShop.WebUI.Settings;
using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace GMAShop.WebUI.Services.Concrete
{
    public class ClientCredentialTokenService(
        IOptions<ServiceApiSettings> serviceApiSettings,
        HttpClient httpClient,
        IClientAccessTokenCache clientAccessTokenCache,
        IOptions<ClientSettings> clientSettings)
        : IClientCredentialTokenService
    {
        private readonly ServiceApiSettings _serviceApiSettings = serviceApiSettings.Value;
        private readonly ClientSettings _clientSettings = clientSettings.Value;

        public async Task<string> GetToken()
        {
            var token1 = await clientAccessTokenCache.GetAsync("gmashoptoken");
            if (token1 != null)
            {
                return token1.AccessToken;
            }
            
            var discoveryEndPoint = await httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServerUrl,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false 
                }
            });



            var clientCredentialTokenRequest = new ClientCredentialsTokenRequest
            {
                ClientId = _clientSettings.GMAShopVisitorClient.ClientId,
                ClientSecret = _clientSettings.GMAShopVisitorClient.ClientSecret,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token2 = await httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
            await clientAccessTokenCache.SetAsync("gmashoptoken", token2.AccessToken, token2.ExpiresIn);
            return token2.AccessToken;
        }
    }
}
