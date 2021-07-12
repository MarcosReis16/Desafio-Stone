using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stone.API.Configuration;
using Stone.Utilitarios.Filtros.Excecao;
using System.Text.Json.Serialization;

namespace Stone.API
{
    /// <summary>
    /// Classe Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Instância de configuração
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration">Instância de configuração</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configurar Serviços
        /// </summary>
        /// <param name="services">Serviços</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options => options.Filters.Add(typeof(ApiExcecaoFiltros)))
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.MaxDepth = 0;
                        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
                        //options.JsonSerializerOptions.WriteIndented = true;
                    })
                    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.ConfigurarSwagger();

            services.AddAutoMapper(typeof(Startup));

            services.AddMemoryCache();

            services.ResolveDependencies();

            services.ConfigurarAutenticacao(Configuration);

            services.AddIdentityConfiguration(Configuration);
            
        }

        /// <summary>
        /// Configuração da aplicação
        /// </summary>
        /// <param name="app">Administrador da aplicação</param>
        /// <param name="env">Web Host ambiente</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Desafio Stone v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
