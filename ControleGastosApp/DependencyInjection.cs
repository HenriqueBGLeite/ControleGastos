using ControleGastos.Core.Application.UseCases.RegisterUser;
using ControleGastos.Core.Domain.Repositories;
using ControleGastosApp.Pages;
using ControleGastosApp.Services.Navigate;
using ControleGastosApp.ViewModels;
using ControleGastosApp.ViewModels.FormModels;
using Database.Config;
using Database.Repositories.Categories;
using Database.Repositories.Transactions;
using Database.Repositories.Users;
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

            return services;
        }

        private static IServiceCollection AddFormModels(this IServiceCollection services)
        {
            services.AddTransient<AuthFormModel>();
            services.AddTransient<RegisterUserFormModel>();

            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<INavigateService, NavigateService>();

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

            return services;
        }

        private static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
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
