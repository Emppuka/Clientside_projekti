using Microsoft.Extensions.Logging;
using LifeManagementApp.Services;
using LifeManagementApp.Views;


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
#endif

            return builder.Build();
        }
    }
}
