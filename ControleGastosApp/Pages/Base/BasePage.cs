using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using ControleGastosApp.ViewModels.Base;
using CommunityToolkit.Maui.PlatformConfiguration.AndroidSpecific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Pages.Base
{
    public class BasePage : ContentPage
    {
        // ====== StatusBar ======
        protected virtual Color DefaultStatusBarColor => (Color)Application.Current!.Resources["StatusBar"];
        protected virtual StatusBarStyle DefaultStatusBarStyle => StatusBarStyle.DarkContent;
        protected virtual StatusBarApplyOn ApplyOn => StatusBarApplyOn.OnPageNavigatedTo;

        // ====== NavigationBar ======
        protected virtual Color AndroidNavBarColor => (Color)Application.Current!.Resources["NavigationBar"];
        protected virtual NavigationBarStyle AndroidNavBarStyle => NavigationBarStyle.DarkContent;

        public BasePage()
        {
#if ANDROID
        NavigationBar.SetColor(this, AndroidNavBarColor);
        NavigationBar.SetStyle(this, AndroidNavBarStyle);
#endif

#if ANDROID || IOS
            Behaviors.Add(new StatusBarBehavior
            {
                StatusBarColor = DefaultStatusBarColor,
                StatusBarStyle = DefaultStatusBarStyle,
                ApplyOn = ApplyOn
            });
#endif
        }
    }
}
