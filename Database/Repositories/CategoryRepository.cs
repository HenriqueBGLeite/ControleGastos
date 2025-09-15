using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Enums;
using ControleGastos.Core.Domain.Repositories;
using Database.Config;
using Microsoft.EntityFrameworkCore;
using Entities = ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Database.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Categories category, CancellationToken ct = default)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(Categories category, CancellationToken ct = default)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Delete(Categories category, CancellationToken ct = default)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<IList<Categories>> GetAll(Guid userId, CancellationToken ct = default)
        {
            return await _db.Categories.Where(c => c.UserId == userId).OrderByDescending(c => c.UpdatedAt.ToString()).ToListAsync(ct);
        }

        public async Task<Categories?> GetById(Guid id, CancellationToken ct = default)
        {
            return await _db.Categories.FirstOrDefaultAsync(c => c.Id == id, ct);
        }

        public async Task<Categories?> GetByNameAndType(string name, OperationType? type, CancellationToken ct = default)
        {
            return await _db.Categories.FirstOrDefaultAsync(c => c.Name == name && c.OperationType == type, ct);
        }
    }
}
