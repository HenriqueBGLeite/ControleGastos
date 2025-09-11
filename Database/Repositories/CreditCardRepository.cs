using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Repositories;
using Database.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Database.Repositories
{
    public class CreditCardRepository : ICreditCardRepository
    {
        private AppDbContext _db;

        public CreditCardRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(CreditCards card, CancellationToken ct = default)
        {
            _db.Cards.Add(card);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(CreditCards card, CancellationToken ct = default)
        {
            _db.Cards.Update(card);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Delete(CreditCards card, CancellationToken ct = default)
        {
            _db.Cards.Remove(card);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<IList<CreditCards>> GetAll(Guid userId, CancellationToken ct = default)
        {
            return await _db.Cards.Where(c => c.UserId == userId).OrderByDescending(c => c.UpdatedAt.ToString()).ToListAsync(ct);
        }

        public async Task<CreditCards?> GetById(Guid id, CancellationToken ct = default)
        {
            return await _db.Cards.FirstOrDefaultAsync(c => c.Id == id, ct);
        }
    }
}
