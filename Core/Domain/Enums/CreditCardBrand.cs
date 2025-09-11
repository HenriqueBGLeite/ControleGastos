using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Domain.Enums
{
    public enum CreditCardBrand
    {
        [Display(Name = "MasterCard")]
        MasterCard,

        [Display(Name = "Visa")]
        Visa,

        [Display(Name = "American Express")]
        AmericanExpress,

        [Display(Name = "Elo")]
        Elo,

        [Display(Name = "Hipercard")]
        Hipercard,

        [Display(Name = "Outro")]
        Other
    }
}
