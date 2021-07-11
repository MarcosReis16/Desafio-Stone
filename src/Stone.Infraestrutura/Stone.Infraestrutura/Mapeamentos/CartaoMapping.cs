using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.Dominio.Classes;

namespace Stone.Infraestrutura.Mapeamentos
{
    /// <summary>
    /// Mapeador da entidade cartão
    /// </summary>
    public class CartaoMapping : IEntityTypeConfiguration<Cartao>
    {
        /// <summary>
        /// Configuração
        /// </summary>
        /// <param name="builder">Construtor</param>
        public void Configure(EntityTypeBuilder<Cartao> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Bandeira)
                   .IsRequired()
                   .HasColumnType("varchar(25)");

            builder.Property(c => c.CodigoDeSeguranca)
                   .IsRequired()
                   .HasColumnType("varchar(3)");

            builder.Property(c => c.NomeDoTitular)
                   .IsRequired()
                   .HasColumnType("varchar(100)");

            builder.Property(c => c.Numero)
                   .IsRequired()
                   .HasColumnType("varchar(16)");

            builder.Property(c => c.Validade)
                   .IsRequired()
                   .HasColumnType("varchar(5)");

            builder.ToTable("Cartoes");
        }
    }
}
