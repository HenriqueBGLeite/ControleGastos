using ControleGastosApp.Pages;

namespace ControleGastosApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("auth/registerUser", typeof(RegisterUserPage));
            Routing.RegisterRoute("main/categories", typeof(CategoryListPage));
            Routing.RegisterRoute("categories/form", typeof(CategoryFormPage));
        }

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
        }
    }
}
