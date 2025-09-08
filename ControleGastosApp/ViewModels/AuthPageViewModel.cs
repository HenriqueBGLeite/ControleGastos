using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
    public partial class AuthPageViewModel : BaseViewModel
    {
        private INavigateService _navigationService;

        [ObservableProperty]
        private AuthFormModel _authForm;

        public AuthPageViewModel(AuthFormModel authForm, 
            INavigateService navigationService)
        {
            _authForm = authForm;
            _navigationService = navigationService;
        }

        [RelayCommand]
        private async Task OnSignInClicked()
        {
            bool isValid = AuthForm.Validate();

            if (!isValid)
                return;

            return;
        }

        [RelayCommand]
        private void OnClickedCreateAccount()
        {
            _navigationService.NavigateToPage("RegisterUser");
        }
    }
}
