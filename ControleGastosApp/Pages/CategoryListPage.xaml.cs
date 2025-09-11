using ControleGastosApp.Pages.Base;
using ControleGastosApp.ViewModels;

namespace ControleGastosApp.Pages;

public partial class CategoryListPage : BasePage
{
	public CategoryListPage(CategoryListPageViewModel model)
	{
		InitializeComponent();
		BindingContext = model;
	}
}