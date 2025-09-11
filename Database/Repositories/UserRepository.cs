using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Repositories;
using Database.Config;
using Microsoft.EntityFrameworkCore;
using Entities = ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Users?> GetByEmail(string email, CancellationToken ct = default)
        {
            return await _db.Users.FirstOrDefaultAsync(u => u.Email == email, ct);
        }

        public async Task Add(Users user, CancellationToken ct = default)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(Users user, CancellationToken ct = default)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync(ct);
        }
    }
}
