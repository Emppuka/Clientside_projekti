using LifeManagementApp.Services;
using LifeManagementApp.ViewModels;
using LifeManagementApp.Views;
using Microsoft.Extensions.Logging;


namespace LifeManagementApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();

            builder.Services.AddSingleton<HttpClient>();

            builder.Services.AddSingleton<WeatherService>();

            builder.Services.AddSingleton<TodoService>();

            builder.Services.AddTransient<HomePage>();

            builder.Services.AddTransient<TodoViewModel>();

            builder.Services.AddTransient<TodoPage>();
#endif

            return builder.Build();
        }
    }
}
