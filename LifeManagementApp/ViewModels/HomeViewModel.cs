using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementApp.Services;

namespace LifeManagementApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly WeatherService _weatherService;

    [ObservableProperty]
    private double temperature;

    [ObservableProperty]
    private double windSpeed;

    [ObservableProperty]
    private string kiteMessage = "";

    public HomeViewModel(WeatherService weatherService)
    {
        _weatherService = weatherService;
        LoadWeatherCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadWeather()
    {
        var weather = await _weatherService.GetWeatherAsync();

        if (weather == null)
            return;

        Temperature = weather.current.temperature_2m;
        WindSpeed = weather.current.wind_speed_10m;

        if (WindSpeed > 5)
        {
            KiteMessage = "🌊 Good weather for kitesurfing!";
        }
        else
        {
            KiteMessage = "No kitesurfing conditions.";
        }
    }
}