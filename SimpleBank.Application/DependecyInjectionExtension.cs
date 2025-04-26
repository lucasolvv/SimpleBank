using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SimpleBank.Application.Services.AutoMapper;
using SimpleBank.Application.UseCases.User.Register;

namespace SimpleBank.Application
{
    public static class DependecyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCases(services);
            AddAutomapper(services);
        }

        private static void AddAutomapper(this IServiceCollection services)
        {
            services.AddScoped( option => new AutoMapper.MapperConfiguration(option => 
            option.AddProfile(new AutoMapping())).CreateMapper());
        }

        private static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        }
    }
}
