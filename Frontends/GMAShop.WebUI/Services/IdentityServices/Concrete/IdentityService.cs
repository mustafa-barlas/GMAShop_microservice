using System.Globalization;
using System.Security.Claims;
using GMAShop.DtoLayer.IdentityDtos.LoginDtos;
using GMAShop.WebUI.Services.IdentityServices.Abstract;
using GMAShop.WebUI.Settings;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;

namespace GMAShop.WebUI.Services.IdentityServices.Concrete
{
    public class IdentityService(
        IOptions<ClientSettings> clientSettings,
        IOptions<ServiceApiSettings> serviceApiSettings,
        HttpClient httpClient,
        IHttpContextAccessor httpContextAccessor)
        : IIdentityService
    {
        private readonly ClientSettings _clientSettings = clientSettings.Value;
        private readonly ServiceApiSettings _serviceApiSettings = serviceApiSettings.Value;

        public async Task<bool> GetRefreshToken()
        {
            var discoveryEndPoint = await httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServer,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            if (httpContextAccessor.HttpContext != null)
            {
                var refreshToken =
                    await httpContextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

                RefreshTokenRequest refreshTokenRequest = new()
                {
                    ClientId = _clientSettings.GMAShopManagerClient.ClientId,
                    ClientSecret = _clientSettings.GMAShopManagerClient.ClientSecret,
                    RefreshToken = refreshToken,
                    Address = discoveryEndPoint.TokenEndpoint
                };

                var token = await httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

                var authenticationToken = new List<AuthenticationToken>()
                {
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.AccessToken,
                        Value = token.AccessToken
                    },
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.RefreshToken,
                        Value = token.RefreshToken
                    },
                    new AuthenticationToken
                    {
                        Name = OpenIdConnectParameterNames.ExpiresIn,
                        Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString(CultureInfo.CurrentCulture)
                    }
                };

                var result = await httpContextAccessor.HttpContext.AuthenticateAsync();

                var properties = result.Properties;
                if (properties != null)
                {
                    properties.StoreTokens(authenticationToken);

                    if (result.Principal != null)
                        await httpContextAccessor.HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme,
                            result.Principal, properties);
                }
            }

            return true;
        }

        public async Task<bool> SignIn(SignInDto signInDto)
        {
            var discoveryEndPoint = await httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
            {
                Address = _serviceApiSettings.IdentityServer,
                Policy = new DiscoveryPolicy
                {
                    RequireHttps = false
                }
            });

            var passwordTokenRequest = new PasswordTokenRequest
            {
                ClientId = _clientSettings.GMAShopManagerClient.ClientId,
                ClientSecret = _clientSettings.GMAShopManagerClient.ClientSecret,
                UserName = signInDto.Username,
                Password = signInDto.Password,
                Address = discoveryEndPoint.TokenEndpoint
            };

            var token = await httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

            var userInfoRequest = new UserInfoRequest
            {
                Token = token.AccessToken,
                Address = discoveryEndPoint.UserInfoEndpoint
            };

            var userValues = await httpClient.GetUserInfoAsync(userInfoRequest);

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(userValues.Claims,
                CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            var authenticationProperties = new AuthenticationProperties();

            authenticationProperties.StoreTokens(new List<AuthenticationToken>()
            {
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.AccessToken,
                    Value = token.AccessToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.RefreshToken,
                    Value = token.RefreshToken
                },
                new AuthenticationToken
                {
                    Name = OpenIdConnectParameterNames.ExpiresIn,
                    Value = DateTime.Now.AddSeconds(token.ExpiresIn).ToString(CultureInfo.CurrentCulture)
                }
            });

            authenticationProperties.IsPersistent = false;

            if (httpContextAccessor.HttpContext != null)
                await httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    claimsPrincipal, authenticationProperties);

            return true;
        }
    }
}