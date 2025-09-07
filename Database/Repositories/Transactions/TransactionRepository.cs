using Database.Config;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Transactions
{
    public class TransactionRepository : ITransactionRepository
    {
        private AppDbContext _db;

        public TransactionRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(TransactionModel transaction, CancellationToken ct = default)
        {
            _db.Transactions.Add(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(TransactionModel transaction, CancellationToken ct = default)
        {
            _db.Transactions.Update(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Delete(TransactionModel transaction, CancellationToken ct = default)
        {
            _db.Transactions.Remove(transaction);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<TransactionModel?> GetById(Guid id, CancellationToken ct = default)
        {
            return await _db.Transactions.FirstOrDefaultAsync(t => t.Id == id, ct);
        }

        public async Task<IList<TransactionModel>> GetAll(Guid userId, CancellationToken ct = default)
        {
            return await _db.Transactions.Where(t => t.UserId == userId).OrderByDescending(t => t.UpdatedAt.ToString()).ToListAsync(ct);
        }

        public async Task<IList<TransactionModel>> GetByCategory(Guid categoryId, CancellationToken ct = default)
        {
            return await _db.Transactions.Where(t => t.CategoryId == categoryId).OrderByDescending(t => t.UpdatedAt.ToString()).ToListAsync(ct);
        }
    }
}
