
using ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Core.Application.UseCases.Auth
{
    public interface IAuthUseCase
    {
        Task<Users> OnValidateUserToDatabase(string email, CancellationToken ct = default);
    }
}