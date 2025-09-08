using CommunityToolkit.Mvvm.ComponentModel;
using ControleGastosApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels.FormModels
{
    public partial class RegisterUserFormModel : BaseFormModel
    {
        [ObservableProperty]
        [Required(ErrorMessage = "O nome é obrigatório.")]
        private string? _userName;

        [ObservableProperty]
        private string? _userNameErrorMessage;

        [ObservableProperty]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado esta inválido.")]
        private string? _email;

        [ObservableProperty]
        private string? _emailErrorMessage;

        public RegisterUserFormModel()
        {
            WireErrors(
                (nameof(UserName), v => UserNameErrorMessage = v),
                (nameof(Email), v => EmailErrorMessage = v)
            );
        }
    }
}
