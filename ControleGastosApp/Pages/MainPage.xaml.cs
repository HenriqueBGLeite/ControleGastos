using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using ControleGastosApp.Pages.Base;
using ControleGastosApp.Pages.Controls.Popups;
using ControleGastosApp.ViewModels;

namespace ControleGastosApp.Pages;

public partial class MainPage : BasePage
{
    public MainPage(MainPageViewModel model)
    {
        InitializeComponent();
        BindingContext = model;
    }

    protected override Color DefaultStatusBarColor => (Color)Application.Current!.Resources["White"];
}