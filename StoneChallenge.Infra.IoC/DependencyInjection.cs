using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StoneChallenge.Application.Interfaces;
using StoneChallenge.Application.Services;
using StoneChallenge.Domain.Interfaces.Repositories;
using StoneChallenge.Infra.Data.Repositories;

namespace StoneChallenge.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                                IConfiguration configuration)
        {
            // Repository Injection
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            // Services Injection
            services.AddScoped<IFuncionarioService, FuncionarioService>();

            return services;
        }
    }
}