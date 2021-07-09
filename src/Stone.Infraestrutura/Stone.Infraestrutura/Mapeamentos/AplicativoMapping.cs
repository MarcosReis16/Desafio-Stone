using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.Dominio.Classes;
using System;

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

            builder.HasData(
                Aplicativo.Create(Guid.NewGuid(), "App1", 35),
                Aplicativo.Create(Guid.NewGuid(), "App2", 12.5m),
                Aplicativo.Create(Guid.NewGuid(), "App3", 7.8m)
            );

            builder.ToTable("Aplicativos");
        }
    }
}
