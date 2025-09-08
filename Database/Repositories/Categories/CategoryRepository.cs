using ControleGastos.Core.Domain.Repositories;
using Database.Config;
using Microsoft.EntityFrameworkCore;
using Entities = ControleGastos.Core.Domain.Entities;

namespace Database.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(Entities.Categories category, CancellationToken ct = default)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(Entities.Categories category, CancellationToken ct = default)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Delete(Entities.Categories category, CancellationToken ct = default)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<IList<Entities.Categories>> GetAll(Guid userId, CancellationToken ct = default)
        {
            return await _db.Categories.Where(c => c.UserId == userId).OrderByDescending(c => c.UpdatedAt.ToString()).ToListAsync(ct);
        }

        public async Task<Entities.Categories?> GetById(Guid id, CancellationToken ct = default)
        {
            return await _db.Categories.FirstOrDefaultAsync(c => c.Id == id, ct);
        }
    }
}
