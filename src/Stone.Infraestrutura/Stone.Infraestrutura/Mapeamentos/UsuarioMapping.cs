using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.Dominio.Classes;

namespace Stone.Infraestrutura.Mapeamentos
{
    /// <summary>
    /// Mapeador de usuário
    /// </summary>
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        /// <summary>
        /// Configuração
        /// </summary>
        /// <param name="builder">Construtor</param>
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(u => u.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.Property(u => u.DataDeNascimento)
                .IsRequired();

            builder.Property(u => u.Sexo)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(u => u.Endereco)
                .WithOne(e => e.Usuario)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
