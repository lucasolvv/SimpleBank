using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleBank.Domain.Repositories.User;
using SimpleBank.Infra.Context;
using SimpleBank.Infra.DataAccess.Repositories;

namespace SimpleBank.Infra
{
    public static class DependecyInjectionExtension
    {
        public static void AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext_SqLite(services, configuration);
            AddRepositories(services);
        }

        private static void AddDbContext_SqLite(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SimpleBankDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SQLITE")));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
            services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        }
    }
}
