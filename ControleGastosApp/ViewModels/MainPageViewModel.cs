using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControleGastos.Core.Domain.Enums;
using ControleGastosApp.Services.Alert;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.Services.Session;
using ControleGastosApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private INavigateService _navigationService;
        private IShellAlertService _shellAlertService;
        private ISessionService _sessionService;

        #region Operações
        [ObservableProperty]
        private TypeOperations _cardsOperation = TypeOperations.cards;
        [ObservableProperty]
        private TypeOperations _categoriesOperation = TypeOperations.categories;
        [ObservableProperty]
        private TypeOperations _transactionsOperation = TypeOperations.transactions;
        [ObservableProperty]
        private TypeOperations _planningOperation = TypeOperations.planning;
        [ObservableProperty]
        private TypeOperations _settingsOperation = TypeOperations.settings;
        #endregion

        public MainPageViewModel(INavigateService navigationService,
            IShellAlertService shellAlertService,
            ISessionService sessionService)
        {
            _navigationService = navigationService;
            _shellAlertService = shellAlertService;
            _sessionService = sessionService;
        }

        [RelayCommand]
        private async Task OnClickedLogout()
        {
            if (!await _shellAlertService.ShowConfirmationAsync("Sair do sistema", "Deseja realmente sair?"))
                return;

            _sessionService.Logout();
            await _navigationService.NavigateToRootAsync("auth");
        }

        [RelayCommand]
        private async Task OnNavigateToPage(TypeOperations type)
        {
            string route = (type) switch
            {
                TypeOperations.cards => "cards",
                TypeOperations.categories => "categories",
                TypeOperations.transactions => "transactions",
                TypeOperations.planning => "planning",
                TypeOperations.settings => "settings",
                _ => throw new NotImplementedException(),
            };

            //await _navigationService.NavigateToAsync(route);
        }
    }
}
