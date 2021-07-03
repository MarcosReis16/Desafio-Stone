using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Stone.API.Configuration
{
    /// <summary>
    /// Classe responsável pelas configurações do identity
    /// </summary>
    public static class IdentityConfiguration
    {
        /// <summary>
        /// Método de extensão responsável pela configuração do identity
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="configuration">Configuration</param>
        /// <returns></returns>
        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services,
                                                                  IConfiguration configuration)
        {
            services.AddDbContext<MeuDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentityCore<IdentityUser>()
                    .AddEntityFrameworkStores<MeuDbContext>()
                    .AddDefaultTokenProviders();
            return services;
        }
    }
}
