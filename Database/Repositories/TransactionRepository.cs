using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Repositories;
using Database.Config;
using Microsoft.EntityFrameworkCore;
using Entities = ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Database.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private AppDbContext _db;

        public TransactionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Transactions transaction, CancellationToken ct = default)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(Transactions transaction, CancellationToken ct = default)
        {
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Delete(Transactions transaction, CancellationToken ct = default)
        {
            _db.Transactions.Remove(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<Transactions?> GetById(Guid id, CancellationToken ct = default)
        {
            return await _db.Transactions.FirstOrDefaultAsync(t => t.Id == id, ct);
        }

        public async Task<IList<Transactions>> GetAll(Guid userId, CancellationToken ct = default)
        {
            return await _db.Transactions.Where(t => t.UserId == userId).OrderByDescending(t => t.UpdatedAt.ToString()).ToListAsync(ct);
        }

        public async Task<IList<Transactions>> GetByCategory(Guid categoryId, CancellationToken ct = default)
        {
            return await _db.Transactions.Where(t => t.CategoryId == categoryId).OrderByDescending(t => t.UpdatedAt.ToString()).ToListAsync(ct);
        }
    }
}
