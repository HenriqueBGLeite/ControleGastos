namespace ControleGastosApp.Services.Storage
{
    public interface IPreferencesStorage
    {
        string? Get(string key);
        void Remove(string key);
        void Set(string key, string value);
    }
}