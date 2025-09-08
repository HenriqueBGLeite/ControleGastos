using CommunityToolkit.Mvvm.Input;
using ControleGastosApp.Services.Alert;
using ControleGastosApp.Services.Navigate;
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

        public MainPageViewModel(INavigateService navigationService, 
            IShellAlertService shellAlertService)
        {
            _navigationService = navigationService;
            _shellAlertService = shellAlertService;
        }

        [RelayCommand]
        private async Task OnClickedLogout()
        {
            if (!await _shellAlertService.ShowConfirmationAsync("Sair do sistema", "Deseja realmente sair?"))
                return;

            await _navigationService.NavigateToRootAsync("auth");
        }
    }
}
