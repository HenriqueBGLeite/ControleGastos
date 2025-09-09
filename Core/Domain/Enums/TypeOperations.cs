using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Domain.Enums
{
    public enum TypeOperations
    {
        [Display(Name = "Cartões")]
        cards,

        [Display(Name = "Categorias")]
        categories,
        
        [Display(Name = "Transações")]
        transactions,

        [Display(Name = "Planejamento")]
        planning,

        [Display(Name = "Configurações")]
        settings
    }
}
