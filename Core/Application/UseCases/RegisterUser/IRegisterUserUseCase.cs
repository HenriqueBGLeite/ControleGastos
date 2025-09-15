using ControleGastos.Core.Domain.Entities;

namespace ControleGastos.Core.Application.UseCases.RegisterUser
{
    public interface IRegisterUserUseCase
    {
        Task OnRegisterUserInDatabase(Users user, CancellationToken ct = default);
    }
}