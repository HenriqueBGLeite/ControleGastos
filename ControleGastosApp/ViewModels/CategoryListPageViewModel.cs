using CommunityToolkit.Mvvm.Input;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels
{
    public partial class CategoryListPageViewModel : BaseViewModel
    {
        private INavigateService _navigationService;

        public CategoryListPageViewModel(INavigateService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void OnTapToBack()
        {
            _navigationService.NavigateToRootAsync("main");
        }
    }
}
