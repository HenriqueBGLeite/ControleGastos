using ControleGastos.Core.Domain.Entities;
using ControleGastosApp.Services.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ControleGastosApp.Services.Session
{
    public class SessionService : ISessionService
    {
        private static string _key = "user.logged";
        private IPreferencesStorage _storage;

        public SessionService(IPreferencesStorage storage)
        {
            _storage = storage;
        }

        public void SetUserLogged(Users user)
        {
            var userJson = JsonSerializer.Serialize(user);
            _storage.Set(_key, userJson);
        }

        public Users? GetUserLogged()
        {
            var userJson = _storage.Get(_key);

            if (string.IsNullOrEmpty(userJson))
                return null;

            return JsonSerializer.Deserialize<Users>(userJson);
        }

        public void Logout()
        {
            if (_storage.Get(_key) != null)
                _storage.Remove(_key);
        }
    }
}
