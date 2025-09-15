using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using ControleGastos.Core.Application.UseCases.RegisterCategories;
using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Enums;
using ControleGastosApp.Services.Alert;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.Services.Session;
using ControleGastosApp.ViewModels.Base;
using ControleGastosApp.ViewModels.FormModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ControleGastosApp.ViewModels
{
    [QueryProperty(nameof(CategoryParameter), "Category")]
    public partial class CategoryFormPageViewModel : BaseViewModel
    {
        private INavigateService _navigationService;
        private IShellAlertService _shellAlertService;
        private ISessionService _sessionService;
        private IRegisterCategoryUseCase _registerCategoryUseCase;

        public IEnumerable<OperationType> OperationTypes { get; } = Enum.GetValues(typeof(OperationType)).Cast<OperationType>();

        [ObservableProperty]
        public partial RegisterCategoryFormModel CategoryForm {  get; set; }

        [ObservableProperty]
        public partial Categories? CategoryParameter { get; set; }

        public CategoryFormPageViewModel(INavigateService navigateService,
            RegisterCategoryFormModel categoryForm,
            IShellAlertService shellAlertService,
            ISessionService sessionService,
            IRegisterCategoryUseCase registerCategoryUseCase)
        {
            CategoryForm = categoryForm;
            _navigationService = navigateService;
            _shellAlertService = shellAlertService;
            _sessionService = sessionService;
            _registerCategoryUseCase = registerCategoryUseCase;
        }

        partial void OnCategoryParameterChanged(Categories? value)
        {
            if (value is null)
                return;

            CategoryForm.Name = value.Name;
            CategoryForm.Type = value.OperationType;
        }

        [RelayCommand]
        private async Task OnSavedCategoryOnDatabase()
        {
            try
            {
                bool isValid = CategoryForm.Validate();

                if (!isValid)
                    return;

                if (CategoryParameter is not null)
                {
                    CategoryParameter.Name = CategoryForm.Name;
                    CategoryParameter.OperationType = CategoryForm.Type;

                    await _registerCategoryUseCase.OnEditCategoryInDatabase(CategoryParameter);

                    //TODO - Implementar snackbar para registro criado com sucesso!
                    await _shellAlertService.ShowSnackBar("Registro alterado com sucesso.");
                }
                else
                {
                    var userLogged = _sessionService.GetUserLogged();

                    Categories category = new()
                    {
                        Name = CategoryForm.Name,
                        OperationType = CategoryForm.Type,
                        Icone = "category_default.png",
                        Color = "#E7ECB7",
                        UserId = userLogged!.Id
                    };

                    await _registerCategoryUseCase.OnRegisterCategoryInDatabase(category);

                    //TODO - Implementar snackbar para registro criado com sucesso!
                    await _shellAlertService.ShowSnackBar("Registro salvo com sucesso");
                }

                WeakReferenceMessenger.Default.Send(string.Empty);

                await _navigationService.GoBackAsync();
            }
            catch (Exception ex)
            {
                //TODO - Implementar snackbar para erro ao criado
                await _shellAlertService.ShowSnackBar($"Erro ao salvar registro. \n\n {ex.Message}");
            }
        }

        [RelayCommand]
        private void OnTapToBack()
        {
            _navigationService.GoBackAsync();
        }
    }
}
