using Microsoft.Extensions.DependencyInjection;

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

            return services;
        }
    }
}
