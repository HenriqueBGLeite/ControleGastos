using ControleGastos.Core.Domain.Enums;
using ControleGastosApp.Pages.Base;
using ControleGastosApp.ViewModels;
using System.ComponentModel;

namespace ControleGastosApp.Pages;

public partial class CategoryListPage : BasePage
{
	private CategoryListPageViewModel _vm => (CategoryListPageViewModel)BindingContext;

    public CategoryListPage(CategoryListPageViewModel model)
	{
		InitializeComponent();
		BindingContext = model;

		model.PropertyChanged += Vm_PropertyChanged;
	}

    protected override Color AndroidNavBarColor => (Color)Application.Current!.Resources["White"];

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        _vm.PropertyChanged -= Vm_PropertyChanged;
    }

    private async void Vm_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CategoryListPageViewModel.SelectedOperation))
            await AnimateSelectionAsync(_vm.SelectedOperation);
    }

    private async Task AnimateSelectionAsync(OperationType? op)
    {
        var selected = op == OperationType.Expense ? ExpenseBorder : IncomeBorder;
        var other = op == OperationType.Expense ? IncomeBorder : ExpenseBorder;

        await Task.WhenAll(
            selected.ScaleTo(1.03, 110, Easing.CubicOut),
            other.FadeTo(0.9, 110, Easing.CubicOut)
        );
        await Task.WhenAll(
            selected.ScaleTo(1.00, 80, Easing.CubicOut),
            other.FadeTo(1.0, 80)
        );
    }
}