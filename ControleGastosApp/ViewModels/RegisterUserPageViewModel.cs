using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControleGastos.Core.Application.UseCases.RegisterUser;
using ControleGastos.Core.Domain.Entities;
using ControleGastosApp.Services.Alert;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.ViewModels.Base;
using ControleGastosApp.ViewModels.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels
{
    public partial class RegisterUserPageViewModel : BaseViewModel
    {
        private INavigateService _navigationService;
        private IShellAlertService _shellAlertService;
        private IRegisterUserUseCase _registerUserUseCase;

        [ObservableProperty]
        private RegisterUserFormModel _userForm;

        public RegisterUserPageViewModel(RegisterUserFormModel userForm,
            INavigateService navigationService,
            IRegisterUserUseCase registerUserUseCase,
            IShellAlertService shellAlertService)
        {
            _userForm = userForm;
            _navigationService = navigationService;
            _registerUserUseCase = registerUserUseCase;
            _shellAlertService = shellAlertService;
        }

        [RelayCommand]
        private async Task OnClickedRegisterUser()
        {
            try
            {
                bool isValid = UserForm.Validate();

                if (!isValid)
                    return;

                Users userDb = new ()
                {
                    Name = UserForm.UserName,
                    Email = UserForm.Email,
                };

                await _registerUserUseCase.OnRegisterUserToDatabase(userDb);

                //TODO - Implementar snackbar para registro criado com sucesso!

                await _shellAlertService.ShowSnackBarAsync("Registro salvo com sucesso");

                await _navigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                //TODO - Implementar snackbar para erro ao criado
                await _shellAlertService.ShowSnackBarAsync($"Erro ao salvar registro. \n\n {ex.Message}");
            }
        }

        [RelayCommand]
        private void OnTapToBack()
        {
            _navigationService.GoBackAsync();
        }
    }
}
