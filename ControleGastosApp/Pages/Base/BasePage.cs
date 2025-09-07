using CommunityToolkit.Maui.Behaviors;
using CommunityToolkit.Maui.Core;
using ControleGastosApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Pages.Base
{
    public class BasePage : ContentPage
    {
        protected virtual Color DefaultStatusBarColor => (Color)Application.Current!.Resources["StatusBar"];
        protected virtual StatusBarStyle DefaultStatusBarStyle => StatusBarStyle.DarkContent;
        protected virtual StatusBarApplyOn ApplyOn => StatusBarApplyOn.OnPageNavigatedTo;

        public BasePage()
        {

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
