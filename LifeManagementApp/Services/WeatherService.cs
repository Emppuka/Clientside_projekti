using LifeManagementApp.Models;
using System.Net.Http.Json;

namespace LifeManagementApp.Services;

public class WeatherService
{
    private readonly HttpClient _httpClient;

    public WeatherService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<WeatherResponse?> GetWeatherAsync()
    {
        string url =
            "https://api.open-meteo.com/v1/forecast?latitude=62.79&longitude=22.84&current=temperature_2m,wind_speed_10m";

        return await _httpClient.GetFromJsonAsync<WeatherResponse>(url);
    }
}