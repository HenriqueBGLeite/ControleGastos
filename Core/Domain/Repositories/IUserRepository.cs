using ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Core.Domain.Repositories
{
    public interface IUserRepository
    {
        Task Add(Users user, CancellationToken ct = default);
        Task<Users?> GetByEmail(string email, CancellationToken ct = default);
        Task Update(Users user, CancellationToken ct = default);
    }
}