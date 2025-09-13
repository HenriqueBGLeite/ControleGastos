using CommunityToolkit.Mvvm.ComponentModel;
using ControleGastos.Core.Domain.Enums;
using ControleGastosApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.ViewModels.FormModels
{
    public partial class RegisterCategoryFormModel : BaseFormModel
    {
        [ObservableProperty]
        [Required(ErrorMessage = "Nome da categoria é obrigatório.")]
        public partial string? Name { get; set; }

        [ObservableProperty]
        public partial string? NameErrorMessage {  get; set; }

        [ObservableProperty]
        [Required(ErrorMessage = "Tipo da categoria é obrigatório.")]
        public partial OperationType? Type { get; set; }

        [ObservableProperty]
        public partial string? TypeErrorMessage { get; set; }

        public RegisterCategoryFormModel()
        {
            WireErrors(
                (nameof(Name), v => NameErrorMessage = v),
                (nameof(Type), v => TypeErrorMessage = v)
            );
        }
    }
}
