using ControleGastosApp.Pages.Base;
using ControleGastosApp.ViewModels;

namespace ControleGastosApp.Pages;

public partial class AuthPage : BasePage
{
	public AuthPage(AuthPageViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}