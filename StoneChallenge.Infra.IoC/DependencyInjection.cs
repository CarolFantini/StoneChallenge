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
            // Repositories Injection
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IAreasAtuacaoRepository, AreasAtuacaoRepository>();

            // Services Injection
            services.AddScoped<IPesosDistribuicaoLucrosService, PesosDistribuicaoLucrosService>();

            return services;
        }
    }
}