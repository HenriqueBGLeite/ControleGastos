using Database.Config;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private AppDbContext _db;

        public CategoryRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task Add(CategoryModel category, CancellationToken ct = default)
        {
            _db.Categories.Add(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(CategoryModel category, CancellationToken ct = default)
        {
            _db.Categories.Update(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Delete(CategoryModel category, CancellationToken ct = default)
        {
            _db.Categories.Remove(category);
            await _db.SaveChangesAsync(ct);
        }

        public async Task<IList<CategoryModel>> GetAll(Guid userId, CancellationToken ct = default)
        {
            return await _db.Categories.Where(c => c.UserId == userId).OrderByDescending(c => c.UpdatedAt.ToString()).ToListAsync(ct);
        }

        public async Task<CategoryModel?> GetById(Guid id, CancellationToken ct = default)
        {
            return await _db.Categories.FirstOrDefaultAsync(c => c.Id == id, ct);
        }
    }
}
