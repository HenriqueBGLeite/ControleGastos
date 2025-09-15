

namespace ControleGastosApp.Services.Navigate
{
    public interface INavigateService
    {
        Task GoBackAsync();
        Task NavigateToAsync(string route);
        Task NavigateToRootAsync(string route);
        Task NavigateWithParametersToAsync(string route, Dictionary<string, object> parameters);
        Task NavigateWithParametersToRootAsync(string route, Dictionary<string, object> parameters);
    }
}