namespace GMAShop.WebUI.Services.IdentityServices.Abstract;

public interface IClientAccessTokenCache
{
    Task SetAsync(string gmashoptoken, string token2AccessToken, int token2ExpiresIn);
    Task GetAsync(string gmashoptoken);
}