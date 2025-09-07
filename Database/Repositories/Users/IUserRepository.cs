using Models;

namespace Database.Repositories.Users
{
    public interface IUserRepository
    {
        Task Add(UserModel user, CancellationToken ct = default);
        UserModel? GetByEmail(string email);
        Task Update(UserModel user, CancellationToken ct = default);
    }
}