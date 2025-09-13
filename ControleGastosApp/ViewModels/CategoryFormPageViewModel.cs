using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControleGastos.Core.Domain.Enums;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.ViewModels.Base;
using ControleGastosApp.ViewModels.FormModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels
{
    public partial class CategoryFormPageViewModel : BaseViewModel
    {
        private INavigateService _navigationService;

        [ObservableProperty]
        public partial OperationType? SelectedOperation { get; set; } = OperationType.Expense;

        [ObservableProperty]
        public partial RegisterCategoryFormModel CategoryForm {  get; set; }

        public CategoryFormPageViewModel(INavigateService navigateService, 
            RegisterCategoryFormModel categoryForm)
        {
            CategoryForm = categoryForm;
            _navigationService = navigateService;
        }

        [RelayCommand]
        private async Task OnSavedCategoryOnDatabase()
        {
            bool isValid = CategoryForm.Validate();

            if (!isValid)
                return;
        }

        [RelayCommand]
        private void OnTapToBack()
        {
            _navigationService.GoBackAsync();
        }
    }
}
