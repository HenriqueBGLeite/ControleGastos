using ControleGastos.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Domain.Entities
{
    public class Transactions
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTimeOffset Date {  get; set; }
        public TransactionType TransactionType { get; set; }
        public bool Repeat { get; set; }
        public int? RepeatCount { get; set; }
        public RecurrencePeriod? RepeatPeriod { get; set; }
        public string? Notes { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Guid UserId { get; set; }
        public Guid CategoryId { get; set; }

        public Users User { get; set; } = null!;
        public Categories Category { get; set; } = null!;
    }
}
