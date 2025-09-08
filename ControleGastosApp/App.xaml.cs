using Microsoft.Maui.Platform;

namespace ControleGastosApp
{
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = default!;

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            CustomHandler();

            UserAppTheme = AppTheme.Light;
            ServiceProvider = serviceProvider;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window();

            var appShellPage = ServiceProvider.GetRequiredService<AppShell>();
            window.Page = appShellPage;

            window.Created += async (s, e) =>
            {
                var initialRoute = await DetermineInitialRouteAsync();
                await appShellPage.GoToAsync(initialRoute);
            };

            return window;
        }

        private Task<string> DetermineInitialRouteAsync()
        {
            return Task.FromResult("//auth");
        }

        private static void CustomHandler()
        {
            EntryNoBorder();
            DatePickerNoBorder();
            PickerNoBorder();
        }

        private static void EntryNoBorder()
        {
            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("EntryBorderless", (handler, view) =>
            {
#if __ANDROID__
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
#elif __IOS__
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            });
        }

        private static void DatePickerNoBorder()
        {
            Microsoft.Maui.Handlers.DatePickerHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
#if ANDROID
                //Android
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());
#elif IOS || MACCATALYST
                //iOS || MACCATALYST
                //handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#elif WINDOWS
                //Windows - Não funciona 100%
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            });
        }

        private static void PickerNoBorder()
        {
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("NoBorder", (handler, view) =>
            {
#if ANDROID
                handler.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToPlatform());

#elif IOS || MACCATALYST
                // iOS / MacCatalyst
                // handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;

#elif WINDOWS
                handler.PlatformView.BorderThickness = new Thickness(0).ToPlatform();
#endif
            });
        }
    }
}