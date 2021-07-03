using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Stone.Infraestrutura.Contextos
{
    /// <summary>
    /// Classe responsável pelo contexto da aplicação
    /// </summary>
    public class MeuDbContext : IdentityDbContext
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="options">DbContextOptions</param>
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        /// <summary>
        /// Método de configuração do modelo
        /// </summary>
        /// <param name="modelBuilder">Construtor de modelo</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Método de configuração
        /// </summary>
        /// <param name="optionsBuilder">Construtor de Opções</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            optionsBuilder.UseLazyLoadingProxies(false);
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));

            base.OnConfiguring(optionsBuilder);
        }
    }
}
