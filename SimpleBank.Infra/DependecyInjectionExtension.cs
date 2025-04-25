using Microsoft.Extensions.DependencyInjection;

namespace SimpleBank.Infra
{
    public static class DependecyInjectionExtension
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services)
        {
            return services;
        }

        //private void AddDbContext(IServiceCollection services)
        //{

        //}

        //private void AddRepositories(IServiceCollection services)
        //{

        //}
    }
}
