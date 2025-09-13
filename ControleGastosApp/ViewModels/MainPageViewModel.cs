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

        #region Operações
        [ObservableProperty]
        public partial TypeOperations CardsOperation { get; set; } = TypeOperations.cards;
        [ObservableProperty]
        public partial TypeOperations CategoriesOperation { get; set; } = TypeOperations.categories;
        [ObservableProperty]
        public partial TypeOperations TransactionsOperation { get; set; } = TypeOperations.transactions;
        [ObservableProperty]
        public partial TypeOperations PlanningOperation { get; set; } = TypeOperations.planning;
        [ObservableProperty]
        public partial TypeOperations SettingsOperation { get; set; } = TypeOperations.settings;
        #endregion

        public List<string> Months { get; } = DateTimeFormatInfo.CurrentInfo!.MonthNames.Where(m => !string.IsNullOrEmpty(m)).ToList();

        [ObservableProperty]
        public partial int SelectedMonth { get; set; } = DateTimeOffset.Now.Month;

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

            await _navigationService.NavigateToAsync(route);
        }
    }
}
