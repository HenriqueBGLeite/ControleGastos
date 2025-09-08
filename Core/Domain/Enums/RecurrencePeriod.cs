using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Domain.Enums
{
    public enum RecurrencePeriod
    {
        [Display(Name = "Diário")]
        Daily,
        [Display(Name = "Semanal")]
        Weekly,
        [Display(Name = "Mensal")]
        Monthly,
        [Display(Name = "Anual")]
        Yearly
    }
}
