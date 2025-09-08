using ControleGastos.Core.Domain.Entities;
using ControleGastos.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastos.Core.Application.UseCases.Auth
{
    public class AuthUseCase : IAuthUseCase
    {
        private IUserRepository _userRepository;

        public AuthUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Users> OnValidateUserToDatabase(string email, CancellationToken ct = default)
        {
            var normalize = email.ToLowerInvariant() ?? string.Empty;

            var userExists = await _userRepository.GetByEmail(normalize, ct);

            if (userExists == null)
                throw new Exception($"Nenhum usuário cadastrado para o e-mail: {email}.");

            return userExists;
        }
    }
}
