namespace ControleGastosApp.Services.Storage
{
    public interface IPreferencesStorage
    {
        string? Get(string key, string? defaultValue);
        void Remove(string key);
        void Set(string key, string value);
    }
}