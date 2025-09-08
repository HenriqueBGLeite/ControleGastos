using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Services.Navigate
{
    public class NavigateService : INavigateService
    {
        public async Task NavigateToRootAsync(string route)
        {
            await Shell.Current.GoToAsync($"//{route}");
        }

        public async Task NavigateToAsync(string route)
        {
            await Shell.Current.GoToAsync(route);
        }

        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}
