using Database.Config;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public UserModel? GetByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email == email);
        }

        public async Task Add(UserModel user, CancellationToken ct = default)
        {
            _db.Users.Add(user);
            await _db.SaveChangesAsync(ct);
        }

        public async Task Update(UserModel user, CancellationToken ct = default)
        {
            _db.Users.Update(user);
            await _db.SaveChangesAsync(ct);
        }
    }
}
