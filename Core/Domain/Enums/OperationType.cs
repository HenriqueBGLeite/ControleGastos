using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Domain.Enums
{
    public enum OperationType
    {
        [Display(Name = "Receita")]
        Income = 1,

        [Display(Name = "Despesa")]
        Expense = 2
    }
}
