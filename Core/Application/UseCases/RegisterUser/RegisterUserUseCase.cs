using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Application.UseCases.RegisterUser
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private IUserRepository _userRepository;

        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task OnRegisterUserToDatabase(Users user, CancellationToken ct = default)
        {
            var normalize = user.Email?.ToLowerInvariant() ?? string.Empty;

            var userExists = await _userRepository.GetByEmail(normalize, ct);

            if (userExists != null)
                throw new Exception("Usuário já existe para esse e-mail.");

            //TODO Implementar o registro de usuario
            user.Id = Guid.NewGuid();
            user.CreatedAt = DateTimeOffset.Now;
            user.UpdatedAt = DateTimeOffset.Now;

            await _userRepository.Add(user);
        }
    }
}
