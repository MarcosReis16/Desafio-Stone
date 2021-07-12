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
        /// Inst�ncia de configura��o
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="configuration">Inst�ncia de configura��o</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configurar Servi�os
        /// </summary>
        /// <param name="services">Servi�os</param>
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
        /// Configura��o da aplica��o
        /// </summary>
        /// <param name="app">Administrador da aplica��o</param>
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
