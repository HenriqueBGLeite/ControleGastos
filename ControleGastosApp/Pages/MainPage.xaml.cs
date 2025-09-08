using ControleGastosApp.Pages.Base;
using ControleGastosApp.ViewModels;

namespace ControleGastosApp.Pages;

public partial class MainPage : BasePage
{
	public MainPage(MainPageViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}