using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Infraestrutura.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Stone.Dominio.Classes;
using System;

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

            services.AddIdentityCore<Usuario>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.User.RequireUniqueEmail = true;
            }).AddRoles<IdentityRole<Guid>>()
              .AddUserManager<UserManager<Usuario>>()
              .AddSignInManager<SignInManager<Usuario>>()
              .AddEntityFrameworkStores<MeuDbContext>()
              .AddDefaultTokenProviders();

            return services;
        }
    }
}
