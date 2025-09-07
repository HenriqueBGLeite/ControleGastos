using Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class TransactionModel
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

        public UserModel User { get; set; } = null!;
        public CategoryModel Category { get; set; } = null!;
    }
}
