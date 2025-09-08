
namespace ControleGastosApp.Services.Navigate
{
    public interface INavigateService
    {
        Task GoBackAsync();
        Task NavigateToAsync(string route);
        Task NavigateToRootAsync(string route);
    }
}