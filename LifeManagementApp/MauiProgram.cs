using LifeManagementApp.Services;
using LifeManagementApp.ViewModels;
using LifeManagementApp.Views;
using LifeManagementApp.Data;
using Microsoft.EntityFrameworkCore;
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

            builder.Services.AddTransient<HomeViewModel>();

            builder.Services.AddTransient<TodoViewModel>();

            builder.Services.AddTransient<TodoPage>();

            string dbPath = Path.Combine(
    FileSystem.AppDataDirectory,
    "LifeManagementApp.db");

            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(
                    $"Data Source={dbPath}");
            });
#endif

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                AppDbContext context =
                    scope.ServiceProvider.GetRequiredService<AppDbContext>();

                context.Database.EnsureCreated(); // Varmistaa tietokannan olemassaolon ja luo sen, jos sitä ei ole.
            }

            return app;
        }
    }
}
