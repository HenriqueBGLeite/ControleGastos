using ControleGastosApp.Pages.Base;
using ControleGastosApp.ViewModels;

namespace ControleGastosApp.Pages;

public partial class RegisterUserPage : BasePage
{
	public RegisterUserPage(RegisterUserPageViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}