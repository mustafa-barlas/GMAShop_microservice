using System.Text.Json;
using GMAShop.RapidApiWebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GMAShop.RapidApiWebUI.Controllers;

public class DefaultController : Controller
{
    private readonly HttpClient _httpClient;

    public DefaultController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    // Şehir parametresi ile WeatherDetails metodunu güncelle
    public async Task<IActionResult> WeatherDetails(string? city)
    {
        // Eğer şehir parametresi null ise, varsayılan olarak 'Ankara' kullan
        city ??= "Ankara";

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://yahoo-weather5.p.rapidapi.com/weather?location={city}&format=json&u=c"),
            Headers =
            {
                { "x-rapidapi-key", "a117ffd5f6mshf7d2d72feb8df5dp157f20jsn23f9d3dd0c7d" },
                { "x-rapidapi-host", "yahoo-weather5.p.rapidapi.com" },
            },
        };

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();

        using var jsonDoc = JsonDocument.Parse(jsonString);
        var root = jsonDoc.RootElement;

        var model = new WeatherViewModel
        {
            City = root.GetProperty("location").GetProperty("city").GetString(),
            Country = root.GetProperty("location").GetProperty("country").GetString(),
            Latitude = root.GetProperty("location").GetProperty("lat").GetDouble(),
            Longitude = root.GetProperty("location").GetProperty("long").GetDouble(),
            Timezone = root.GetProperty("location").GetProperty("timezone_id").GetString(),
            ConditionText = root.GetProperty("current_observation").GetProperty("condition").GetProperty("text")
                .GetString(),
            Temperature = root.GetProperty("current_observation").GetProperty("condition").GetProperty("temperature")
                .GetInt32(),
            Humidity = root.GetProperty("current_observation").GetProperty("atmosphere").GetProperty("humidity")
                .GetInt32(),
            Visibility = root.GetProperty("current_observation").GetProperty("atmosphere").GetProperty("visibility")
                .GetDouble(),
            WindChill = root.GetProperty("current_observation").GetProperty("wind").GetProperty("chill").GetInt32(),
            WindDirection = root.GetProperty("current_observation").GetProperty("wind").GetProperty("direction")
                .GetString(),
            WindSpeed = root.GetProperty("current_observation").GetProperty("wind").GetProperty("speed").GetDouble(),
            Sunrise = root.GetProperty("current_observation").GetProperty("astronomy").GetProperty("sunrise")
                .GetString(),
            Sunset = root.GetProperty("current_observation").GetProperty("astronomy").GetProperty("sunset").GetString(),
            Forecasts = new List<WeatherForecast>()
        };

        foreach (var forecast in root.GetProperty("forecasts").EnumerateArray())
        {
            model.Forecasts.Add(new WeatherForecast
            {
                Day = forecast.GetProperty("day").GetString(),
                Date = DateTimeOffset.FromUnixTimeSeconds(forecast.GetProperty("date").GetInt64()).DateTime,
                High = forecast.GetProperty("high").GetInt32(),
                Low = forecast.GetProperty("low").GetInt32(),
                Description = forecast.GetProperty("text").GetString()
            });
        }

        return View(model);
    }
    
    public async Task<IActionResult> GetExchangeRate(string currency = "USD")
    {
        // Varsayılan olarak USD'yi alıyoruz
        string fromCurrency = currency;
        string toCurrency = "TRY"; // Örneğin, her zaman TRY'ye çevireceğiz

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol={fromCurrency}&to_symbol={toCurrency}&language=TR"),
            Headers =
            {
                { "x-rapidapi-key", "a117ffd5f6mshf7d2d72feb8df5dp157f20jsn23f9d3dd0c7d" },
                { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
            },
        };

        using var response = await _httpClient.SendAsync(request);
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();

        // JSON verisini parse et
        using var jsonDoc = JsonDocument.Parse(jsonString);
        var root = jsonDoc.RootElement;

        // "data" anahtarından döviz kuru bilgilerini al
        var data = root.GetProperty("data");

        // Modeli doldur
        var exchangeRate = new CurrencyExchangeViewModel
        {
            FromSymbol = data.GetProperty("from_symbol").GetString(),
            ToSymbol = data.GetProperty("to_symbol").GetString(),
            ExchangeRate = data.GetProperty("exchange_rate").GetDecimal(),
            PreviousClose = data.GetProperty("previous_close").GetDecimal(),
            LastUpdateUtc = data.GetProperty("last_update_utc").GetString(),
        };

        return View(exchangeRate);
    }

    
    // public async Task<IActionResult> GetExchangeRate()
    // {
    //     var request = new HttpRequestMessage
    //     {
    //         Method = HttpMethod.Get,
    //         RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=TR"),
    //         Headers =
    //         {
    //             { "x-rapidapi-key", "a117ffd5f6mshf7d2d72feb8df5dp157f20jsn23f9d3dd0c7d" },
    //             { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    //         },
    //     };
    //
    //     using var response = await _httpClient.SendAsync(request);
    //     response.EnsureSuccessStatusCode();
    //     var jsonString = await response.Content.ReadAsStringAsync();
    //
    //     // JSON verisini parse et
    //     using var jsonDoc = JsonDocument.Parse(jsonString);
    //     var root = jsonDoc.RootElement;
    //
    //     // "data" anahtarından ilgili veriyi al
    //     var data = root.GetProperty("data");
    //
    //     // Modeli doldur
    //     var exchangeRate = new CurrencyExchangeViewModel
    //     {
    //         FromSymbol = data.GetProperty("from_symbol").GetString(),
    //         ToSymbol = data.GetProperty("to_symbol").GetString(),
    //         ExchangeRate = data.GetProperty("exchange_rate").GetDecimal(),
    //         PreviousClose = data.GetProperty("previous_close").GetDecimal(),
    //         LastUpdateUtc = data.GetProperty("last_update_utc").GetString(),
    //     };
    //
    //     return View(exchangeRate);
    // }
}