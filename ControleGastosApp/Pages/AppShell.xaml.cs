using ControleGastosApp.Pages;

namespace ControleGastosApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("auth/registerUser", typeof(RegisterUserPage));
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
        }
    }
}
