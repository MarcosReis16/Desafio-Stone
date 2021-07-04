using Microsoft.Extensions.DependencyInjection;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Infraestrutura.Contextos;
using Stone.Infraestrutura.Repositorios;
using Stone.Infraestrutura.Repositorios.Base;
using Stone.Servico.Classes;
using Stone.Servico.Interfaces;

namespace Stone.API.Configuration
{
    /// <summary>
    /// Classe responsável pelas configurações de injeção de dependência
    /// </summary>
    public static class DependencyInjectionConfig
    {
        /// <summary>
        /// Método de extensão para resolver as dependências
        /// </summary>
        /// <param name="services">Instância de Service Collection</param>
        /// <returns>Service Collection</returns>
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();

            services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));

            services.AddScoped<IRepositorioDeCartoes, RepositorioDeCartoes>();
            services.AddScoped<IRepositorioDeTransacoes, RepositorioDeTransacoes>();
            services.AddScoped<IRepositorioDeUsuario, RepositorioDeUsuario>();

            services.AddScoped<IServicoDeUsuario, ServicoDeUsuario>();

            return services;
        }
    }
}
