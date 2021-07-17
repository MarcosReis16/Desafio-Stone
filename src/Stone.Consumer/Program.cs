using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stone.Consumer.Serviço;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Infraestrutura.Contextos;
using Stone.Infraestrutura.Repositorios;
using System;
using System.Threading.Tasks;

namespace Stone.Consumer
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IServiceCollection servicos = new ServiceCollection();
            servicos.AddScoped<DbContext, MeuDbContext>();
            servicos.AddSingleton<IRepositorioDeTransacoes, RepositorioDeTransacoes>();
            servicos.AddSingleton<IServicoDeConsumer, ServicoDeConsumer>();

            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            var config = builder.Build();

            servicos.AddDbContext<MeuDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            DbContextOptions<MeuDbContext> options = new DbContextOptions<MeuDbContext>();
            MeuDbContext context = new MeuDbContext(options);
            IRepositorioDeTransacoes repositorioDeTransacoes = new RepositorioDeTransacoes(context);
            IServicoDeConsumer servicoDeConsumer = new ServicoDeConsumer(repositorioDeTransacoes);

            servicoDeConsumer.Processar();


        }

    }
}
