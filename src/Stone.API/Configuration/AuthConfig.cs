using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Stone.Servico.Extensoes;
using System.Text;

namespace Stone.API.Configuration
{
    public static class AuthConfig
    {
        public static IServiceCollection ConfigurarAutenticacao(this IServiceCollection services, IConfiguration configuration)
        {
            var builder = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json")
                 .AddEnvironmentVariables();

            var config = builder.Build();
            var JwtSettingsJson = configuration.GetSection("AppSettings");
            var jwtSettings = JwtSettingsJson.Get<AppSettings>();
            var jwtKey = Encoding.ASCII.GetBytes(jwtSettings.Secret);

            var signinKey = new SymmetricSecurityKey(jwtKey);
            services.Configure<AppSettings>(JwtSettingsJson);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        IssuerSigningKey = signinKey,
                        ValidAudience = jwtSettings.ValidoEm,
                        ValidIssuer = jwtSettings.Emissor,
                        ValidateIssuerSigningKey = true,
                        ValidateLifetime = true,
                        ValidateIssuer = true,
                        ValidateAudience = true
                    };
                })
                .AddIdentityCookies();

            return services;
        }
    }
}
