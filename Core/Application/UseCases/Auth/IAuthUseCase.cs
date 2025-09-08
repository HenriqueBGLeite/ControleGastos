
namespace ControleGastos.Core.Application.UseCases.Auth
{
    public interface IAuthUseCase
    {
        Task<bool> OnValidateUserToDatabase(string email, CancellationToken ct = default);
    }
}