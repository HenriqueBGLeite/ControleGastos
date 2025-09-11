using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControleGastos.Core.Application.UseCases.Auth;
using ControleGastosApp.Services.Alert;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.Services.Session;
using ControleGastosApp.ViewModels.Base;
using ControleGastosApp.ViewModels.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels
{
    public partial class AuthPageViewModel : BaseViewModel
    {
        private INavigateService _navigationService;
        private IShellAlertService _shellAlertService;
        private ISessionService _sessionService;
        private IAuthUseCase _authUseCase;

        [ObservableProperty]
        private AuthFormModel _authForm;

        public AuthPageViewModel(AuthFormModel authForm,
            INavigateService navigationService,
            IAuthUseCase authUseCase,
            IShellAlertService shellAlertService,
            ISessionService sessionService)
        {
            _authForm = authForm;
            _navigationService = navigationService;
            _authUseCase = authUseCase;
            _shellAlertService = shellAlertService;
            _sessionService = sessionService;
        }

        [RelayCommand]
        private async Task OnClickedSignIn()
        {
            try
            {
                bool isValid = AuthForm.Validate();

                if (!isValid)
                    return;

                if (AuthForm.Email != null)
                {
                    var userDb = await _authUseCase.OnValidateUserToDatabase(AuthForm.Email);

                    _sessionService.SetUserLogged(userDb);
                    await _navigationService.NavigateToRootAsync("main");
                }
            }
            catch (Exception ex)
            {
                //TODO - Implementar snackbar para erro ao criado
                await _shellAlertService.ShowSnackBar($"Erro na autentição. \n\n {ex.Message}");
            }
        }

        [RelayCommand]
        private void OnClickedCreateAccount()
        {
            _navigationService.NavigateToAsync("registerUser");
        }
    }
}
