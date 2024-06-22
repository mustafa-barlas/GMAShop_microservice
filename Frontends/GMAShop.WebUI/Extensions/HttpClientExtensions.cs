namespace GMAShop.WebUI.Extensions;

public static class HttpClientExtensions
{
    public static async Task<T> GetAndRead<T>(this HttpClient httpClient, string requestUri)
    {
        try
        {
            var response = await httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
            var values = await response.Content.ReadFromJsonAsync<T>();
            return values ?? Activator.CreateInstance<T>();
        }
        catch (HttpRequestException ex)
        {
            return Activator.CreateInstance<T>();
        }
    }

    public static async Task Post<T>(this HttpClient httpClient, string requestUri, T content)
    {
        try
        {
            await httpClient.PostAsJsonAsync(requestUri, content);
        }
        catch (Exception ex)
        {
            throw new Exception("something");
        }
    }

    public static async Task Put<T>(this HttpClient httpClient, string requestUri, T content)
    {
        try
        {
            await httpClient.PutAsJsonAsync(requestUri, content);
        }

        catch (Exception ex)
        {
            throw new Exception("something");
        }
    }

    public static async Task Delete(this HttpClient httpClient, string requestUri)
    {
        try
        {
            await httpClient.DeleteAsync(requestUri);
        }
        catch (Exception ex)
        {
            throw new Exception("something");
        }
    }
}