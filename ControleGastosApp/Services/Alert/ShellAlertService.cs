using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Extensions;
using ControleGastosApp.Pages.Controls.Popups;
using ControleGastosApp.Services.Alert.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Services.Alert
{
    public class ShellAlertService : IShellAlertService
    {
        private readonly ICurrentPageProvider _pageProvider;
        private CancellationToken? _ct;

        public ShellAlertService(ICurrentPageProvider pageProvider)
        {
            _pageProvider = pageProvider;
        }

        public Task ShowAsync(string title, string message, string cancel = "OK")
        {
            var page = _pageProvider.GetCurrentPage();

            if (page != null)
                return page.DisplayAlert(title, message, cancel);

            return Task.CompletedTask;
        }

        public async Task<bool> ShowConfirmationAsync(string title, string message, string icon, string accept = "Sim", string cancel = "Cancelar")
        {
            var page = _pageProvider.GetCurrentPage();

            if (page != null)
            {
                var confirmationPopup = new ConfirmationPopup
                {
                    Message = message,
                    Icone = icon,
                    Accept = accept,
                    Cancel = cancel,
                    CanBeDismissedByTappingOutsideOfPopup = false
                };

                var confirmation = await page.ShowPopupAsync<bool>(confirmationPopup);

                return await Task.FromResult(confirmation.Result);
            }

            return await Task.FromResult(false);
        }

        public Task ShowSnackBar(string message)
        {
            var page = _pageProvider.GetCurrentPage();

            if (page != null)
                return page.DisplaySnackbar(message);

            return Task.CompletedTask;
        }

    }
}
