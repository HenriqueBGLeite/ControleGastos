using ControleGastos.Core.Domain.Entities;

namespace ControleGastosApp.Services.Session
{
    public interface ISessionService
    {
        Users? GetUserLogged();
        void Logout();
        void SetUserLogged(Users user);
    }
}