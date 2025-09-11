using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControleGastos.Core.Domain.Enums;
using ControleGastosApp.Pages.Controls.Popups;
using ControleGastosApp.Services.Alert;
using ControleGastosApp.Services.Alert.Providers;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.Services.Session;
using ControleGastosApp.ViewModels.Base;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Maui.Controls.Shapes;
using System;
using System.Collections.Generic;
using System.Globalization;
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

        private readonly IPopupService _popupService;
        private readonly ICurrentPageProvider _currentPageProvider;


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

        public List<string> Months { get; } = DateTimeFormatInfo.CurrentInfo!.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToList();

        [ObservableProperty]
        private int _selectedMonth = DateTimeOffset.Now.Month;

        public MainPageViewModel(INavigateService navigationService,
            IShellAlertService shellAlertService,
            ISessionService sessionService,
            ICurrentPageProvider currentPageProvider,
            IPopupService popupService)
        {
            _navigationService = navigationService;
            _shellAlertService = shellAlertService;
            _sessionService = sessionService;
            _currentPageProvider = currentPageProvider;
            _popupService = popupService;
        }

        [RelayCommand]
        private async Task OnClickedLogout()
        {
            if (!await _shellAlertService.ShowConfirmationAsync("Sair do sistema", "Deseja realmente sair?", "logout.png"))
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

            //await _navigationService.NavigateToRootAsync(route);
        }
    }
}
