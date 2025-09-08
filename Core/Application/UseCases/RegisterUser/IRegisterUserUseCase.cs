using ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Core.Application.UseCases.RegisterUser
{
    public interface IRegisterUserUseCase
    {
        Task OnRegisterUserToDatabase(Users user, CancellationToken ct = default);
    }
}