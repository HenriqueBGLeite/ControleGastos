using CommunityToolkit.Maui;
using ControleGastos.Core.Application.UseCases.Auth;
using ControleGastos.Core.Application.UseCases.RegisterUser;
using ControleGastos.Core.Domain.Repositories;
using ControleGastos.Database.Repositories;
using ControleGastosApp.Pages;
using ControleGastosApp.Pages.Controls.Popups;
using ControleGastosApp.Services.Alert;
using ControleGastosApp.Services.Alert.Providers;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.Services.Session;
using ControleGastosApp.Services.Storage;
using ControleGastosApp.ViewModels;
using ControleGastosApp.ViewModels.FormModels;
using Database.Config;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleGastosApp
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMauiServices(this IServiceCollection services)
        {
            return services
                .AddPages()
                .AddPopups()
                .AddFormModels()
                .AddServices()
                .AddDatabase();
        }

        private static IServiceCollection AddPages(this IServiceCollection services)
        {
            services.AddSingleton<AppShell>();

            services.AddTransient<AuthPage>();
            services.AddTransient<AuthPageViewModel>();

            services.AddTransient<RegisterUserPage>();
            services.AddTransient<RegisterUserPageViewModel>();

            services.AddTransient<MainPage>();
            services.AddTransient<MainPageViewModel>();

            services.AddTransient<CategoryListPage>();
            services.AddTransient<CategoryListPageViewModel>();

            services.AddTransient<CategoryFormPage>();
            services.AddTransient<CategoryFormPageViewModel>();

            return services;
        }

        private static IServiceCollection AddPopups(this IServiceCollection services)
        {
            return services;
        }

        private static IServiceCollection AddFormModels(this IServiceCollection services)
        {
            services.AddTransient<AuthFormModel>();
            services.AddTransient<RegisterUserFormModel>();
            services.AddTransient<RegisterCategoryFormModel>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigateService, NavigateService>();
            services.AddSingleton<ISessionService, SessionService>();
            services.AddSingleton<IPreferencesStorage, PreferencesStorage>();
            services.AddSingleton<ICurrentPageProvider, CurrentPageProvider>();
            services.AddSingleton<IShellAlertService, ShellAlertService>();

            return services;
        }

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            return services
                .AddApplicationLayer()
                .AddPersistenceLayer();
        }

        private static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
            services.AddScoped<IAuthUseCase, AuthUseCase>();

            return services;
        }

        private static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICreditCardRepository, CreditCardRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            return services;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection services)
        {
            services.AddSingleton<AppDbContextFactory>();

            services.AddDbContext<AppDbContext>((provider, options) =>
            {
                var dataBasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "appControleGastos.db");

                options.UseSqlite($"Data Source={dataBasePath}");
            });

            return services;
        }

        public static void ApplyMigrations(this IServiceProvider provider)
        {
            using var scope = provider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            context.Database.Migrate();
        }
    }
}
