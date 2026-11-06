namespace LifeManagementApp.Models;

public class WeatherResponse
{
    public CurrentWeather current { get; set; }
}

public class CurrentWeather
{
    public double temperature_2m { get; set; }

    public double wind_speed_10m { get; set; }
}

