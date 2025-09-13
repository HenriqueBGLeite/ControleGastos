using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControleGastos.Core.Domain.Enums;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels
{
    public partial class CategoryListPageViewModel : BaseViewModel
    {
        private INavigateService _navigationService;

        [ObservableProperty]
        public partial OperationType? SelectedOperation { get; set; } = OperationType.Expense;

        public CategoryListPageViewModel(INavigateService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void OnSelectedOperation(OperationType operation)
        {
            SelectedOperation = operation;
        }

        [RelayCommand]
        private async Task OnTapGoToRegisterCategory()
        {
            await _navigationService.NavigateToAsync("form");
        }

        [RelayCommand]
        private async Task OnTapToBack()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
