using CommunityToolkit.Mvvm.ComponentModel;
using ControleGastosApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ControleGastosApp.ViewModels.FormModels
{
    public partial class AuthFormModel : BaseFormModel
    {
        [ObservableProperty]
        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado esta inválido.")]
        public partial string? Email { get; set; }

        [ObservableProperty]
        public partial string? EmailErrorMessage { get; set; }

        public AuthFormModel()
        {
            WireErrors(map: (nameof(Email), v => EmailErrorMessage = v));
        }
    }
}
