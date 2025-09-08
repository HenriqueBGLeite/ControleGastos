using ControleGastos.Core.Domain.Repositories;
using Database.Config;
using Microsoft.EntityFrameworkCore;
using Entities = ControleGastos.Core.Domain.Entities;

namespace Database.Repositories.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private AppDbContext _db;

        public TransactionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Entities.Transactions transaction, CancellationToken ct = default)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(Entities.Transactions transaction, CancellationToken ct = default)
        {
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Delete(Entities.Transactions transaction, CancellationToken ct = default)
        {
            _db.Transactions.Remove(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<Entities.Transactions?> GetById(Guid id, CancellationToken ct = default)
        {
            return await _db.Transactions.FirstOrDefaultAsync(t => t.Id == id, ct);
        }

        public async Task<IList<Entities.Transactions>> GetAll(Guid userId, CancellationToken ct = default)
        {
            return await _db.Transactions.Where(t => t.UserId == userId).OrderByDescending(t => t.UpdatedAt.ToString()).ToListAsync(ct);
        }

        public async Task<IList<Entities.Transactions>> GetByCategory(Guid categoryId, CancellationToken ct = default)
        {
            return await _db.Transactions.Where(t => t.CategoryId == categoryId).OrderByDescending(t => t.UpdatedAt.ToString()).ToListAsync(ct);
        }
    }
}
