using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Receita")]
        Income = 1,

        [Display(Name = "Despesa")]
        Expense = 2
    }
}
