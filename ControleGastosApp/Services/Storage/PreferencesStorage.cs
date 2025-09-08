using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Services.Storage
{
    public class PreferencesStorage : IPreferencesStorage
    {
        public void Set(string key, string value) => Preferences.Set(key, value);
        public string? Get(string key) => Preferences.Default.Get<string>(key, string.Empty);
        public void Remove(string key) => Preferences.Remove(key);
    }
}
