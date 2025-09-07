using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Icone { get; set; }
        public string? Color { get; set; }
        public ICollection<TransactionModel> Transactions { get; set; } = [];
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Guid UserId { get; set; }
        public UserModel User { get; set; } = null!;
    }
}
