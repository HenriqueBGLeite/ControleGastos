using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp.Services.Alert.Providers
{
    public class CurrentPageProvider : ICurrentPageProvider
    {
        public Page? GetCurrentPage() => Application.Current!.Windows.FirstOrDefault()?.Page;
    }
}
