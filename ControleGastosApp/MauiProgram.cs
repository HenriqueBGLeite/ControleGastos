using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace ControleGastosApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            //TODO - Estudar sobre BottomSheet

            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit(static options =>
                {
                    options.SetPopupDefaults(new DefaultPopupSettings
                    {
                        BackgroundColor = Colors.Transparent,
                        Margin = 0,
                        Padding = 0,
                    });

                    options.SetPopupOptionsDefaults(new DefaultPopupOptionsSettings
                    {
                        PageOverlayColor = Color.FromArgb("#80C2C4C6"),
                        Shadow = null,
                        Shape = null,
                    });

                    options.SetShouldEnableSnackbarOnWindows(true);
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("OpenSans-Medium.ttf", "OpenSansMedium");
                    fonts.AddFont("OpenSans-Bold.ttf", "OpenSansBold");
                    fonts.AddFont("OpenSans-ExtraBold.ttf", "OpenSansExtraBold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services
                .AddMauiServices()
                .AddProjectServices();

            var app = builder.Build();
            app.Services.ApplyMigrations();

            return builder.Build();
        }
    }
}
