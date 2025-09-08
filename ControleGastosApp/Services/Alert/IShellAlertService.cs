
namespace ControleGastosApp.Services.Alert
{
    public interface IShellAlertService
    {
        Task ShowAsync(string title, string message, string cancel = "OK");
        Task<bool> ShowConfirmationAsync(string title, string message, string accept = "Sim", string cancel = "Cancelar");
        Task ShowSnackBarAsync(string message);
    }
}