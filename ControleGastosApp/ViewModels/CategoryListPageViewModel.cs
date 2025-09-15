using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ControleGastos.Core.Application.UseCases.RegisterCategories;
using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Enums;
using ControleGastos.Core.Domain.Repositories;
using ControleGastosApp.Services.Alert;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.Services.Session;
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
        private ISessionService _sessionService;
        private IShellAlertService _shellAlertService;
        private IRegisterCategoryUseCase _registerCategoryUseCase;

        [ObservableProperty]
        public partial IList<Categories> ListAllCategories { get; set; } = [];

        [ObservableProperty]
        public partial IList<Categories> ListFilteredCategories { get; set; } = [];

        [ObservableProperty]
        public partial OperationType? SelectedOperation { get; set; } = OperationType.Expense;

        public CategoryListPageViewModel(INavigateService navigationService,
            ISessionService sessionService,
            IShellAlertService shellAlertService,
            IRegisterCategoryUseCase registerCategoryUseCase)
        {
            _navigationService = navigationService;
            _sessionService = sessionService;
            _shellAlertService = shellAlertService;
            _registerCategoryUseCase = registerCategoryUseCase;

            _ = OnLoadingData();

            WeakReferenceMessenger.Default.Register<string>(this, (r, m) =>
            {
                _ = OnLoadingData();
            });
        }

        public async Task OnLoadingData()
        {
            var userLogged = _sessionService.GetUserLogged();

            ListAllCategories = await _registerCategoryUseCase.OnGetAll(userLogged.Id);
            ListFilteredCategories = ListAllCategories.Where(c => c.OperationType == SelectedOperation).ToList();
        }

        [RelayCommand]
        private void OnSelectedOperation(OperationType operation)
        {
            SelectedOperation = operation;
            ListFilteredCategories = ListAllCategories.Where(c => c.OperationType == SelectedOperation).ToList();
        }

        [RelayCommand]
        private async Task OnTapGoToRegisterCategory()
        {
            await _navigationService.NavigateToAsync("form");
        }

        [RelayCommand]
        private async Task OnTapEditFormCategory(Categories category)
        {
            await _shellAlertService.ShowAsync("Edição categoria", "Aqui abrirá para edição.");
        }

        [RelayCommand]
        private async Task OnTapDeleteCategory(Categories category)
        {
            try
            {
                bool isDelete = await _shellAlertService.ShowConfirmationAsync("Deletar categoria", "Deseja realmente deletar essa categoria?", "trash_popup.png");

                if (!isDelete)
                    return;

                await _registerCategoryUseCase.OnDeletedInDatabase(category);

                await OnLoadingData();

                await _shellAlertService.ShowSnackBar("Registro deletado com sucesso.");
            }
            catch (Exception ex)
            {
                await _shellAlertService.ShowSnackBar($"Erro ao deletar registro. \n\n {ex.Message}");
            }
        }

        [RelayCommand]
        private async Task OnTapToBack()
        {
            await _navigationService.GoBackAsync();
        }
    }
}
