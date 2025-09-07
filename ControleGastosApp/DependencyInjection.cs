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
                .AddDatabase();
        }

        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            return services.AddPersistenceLayer();
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
