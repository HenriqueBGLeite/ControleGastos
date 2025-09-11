using ControleGastos.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Domain.Entities
{
    public class CreditCards
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public CreditCardBrand Brand { get; set; }
        public decimal CreditLimit { get; set; }
        public int ClosingDay { get; set; }
        public int DueDay { get; set; }
        public ICollection<Transactions> Transactions { get; set; } = [];
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;
    }
}
