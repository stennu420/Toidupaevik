using Microsoft.Extensions.Logging;
using Toidupaevik.Services;
using Toidupaevik.ViewModels;
using Toidupaevik.Views;
using Plugin.Maui.Audio;

namespace Toidupaevik
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
            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddSingleton<SettingsService>();
            builder.Services.AddSingleton<ThemeService>();
            builder.Services.AddTransient<SettingsPage>();
            builder.Services.AddSingleton(AudioManager.Current);
            builder.Services.AddSingleton<AudioService>();
#endif

            return builder.Build();
        }
    }
}
