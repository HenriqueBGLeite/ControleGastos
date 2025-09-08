using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Domain.Entities
{
    public class Categories
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Icone { get; set; }
        public string? Color { get; set; }
        public ICollection<Transactions> Transactions { get; set; } = [];
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }

        public Guid UserId { get; set; }
        public Users User { get; set; } = null!;
    }
}
