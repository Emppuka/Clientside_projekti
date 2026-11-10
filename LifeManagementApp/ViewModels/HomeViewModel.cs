using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LifeManagementApp.Models;
using LifeManagementApp.Services;
using System.Collections.ObjectModel;
using System.Linq;

namespace LifeManagementApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    private readonly WeatherService _weatherService;

    private readonly TodoService _todoService;

    [ObservableProperty]
    private double temperature;

    [ObservableProperty]
    private double windSpeed;

    [ObservableProperty]
    private string kiteMessage = "";

    public ObservableCollection<TodoItem> TopTodos { get; }
    = new ObservableCollection<TodoItem>();

    public HomeViewModel(
    WeatherService weatherService,
    TodoService todoService)
    {
        _weatherService = weatherService;
        _todoService = todoService;

        _todoService.TodosChanged += LoadTopTodos;

        LoadWeatherCommand.Execute(null);

        LoadTopTodos();
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
            KiteMessage = "🌊 Hyvä keli kitesurffaukselle!";
        }
        else
        {
            KiteMessage = "Ei onnistu kitesurffaus :(";
        }
    }

    private void LoadTopTodos()
    {
        List<TodoItem> topTodos = _todoService
            .GetTodos()
            .OrderBy(todo => todo.Priority)
            .Take(3)
            .ToList();

        TopTodos.Clear();

        foreach (TodoItem todo in topTodos)
        {
            TopTodos.Add(todo);
        }

        OnPropertyChanged(nameof(TopTodos));
    }
}
