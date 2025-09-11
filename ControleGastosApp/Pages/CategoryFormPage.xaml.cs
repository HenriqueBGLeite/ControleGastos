using ControleGastosApp.Pages.Base;
using ControleGastosApp.ViewModels;

namespace ControleGastosApp.Pages;

public partial class CategoryFormPage : BasePage
{
	public CategoryFormPage(CategoryFormPageViewModel model)
	{
		InitializeComponent();
        BindingContext = model;
    }
}