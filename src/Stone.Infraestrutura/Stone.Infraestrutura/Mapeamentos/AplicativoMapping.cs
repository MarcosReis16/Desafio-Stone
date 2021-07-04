using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.Dominio.Classes;

namespace Stone.Infraestrutura.Mapeamentos
{
    public class AplicativoMapping : IEntityTypeConfiguration<Aplicativo>
    {
        public void Configure(EntityTypeBuilder<Aplicativo> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Nome)
                   .IsRequired()
                   .HasColumnType("varchar(20)");

            builder.Property(a => a.Valor)
                   .IsRequired();

            builder.ToTable("Aplicativos");
        }
    }
}
