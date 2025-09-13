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
        public partial string? UserName { get; set; }

        [ObservableProperty]
        public partial string? UserNameErrorMessage { get; set; }

        [ObservableProperty]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado esta inválido.")]
        public partial string? Email { get; set; }

        [ObservableProperty]
        public partial string? EmailErrorMessage { get; set; }

        public RegisterUserFormModel()
        {
            WireErrors(
                (nameof(UserName), v => UserNameErrorMessage = v),
                (nameof(Email), v => EmailErrorMessage = v)
            );
        }
    }
}
