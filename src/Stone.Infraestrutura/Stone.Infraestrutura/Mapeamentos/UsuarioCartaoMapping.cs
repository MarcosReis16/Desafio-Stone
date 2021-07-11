using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.Dominio.Classes;

namespace Stone.Infraestrutura.Mapeamentos
{
    /// <summary>
    /// Classe de mapeamento de um usuário e um cartão
    /// </summary>
    public class UsuarioCartaoMapping : IEntityTypeConfiguration<UsuarioCartao>
    {
        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="builder">Gerenciador</param>
        public void Configure(EntityTypeBuilder<UsuarioCartao> builder)
        {
            builder.HasKey(x => new { x.IdCartao, x.IdUsuario});

            builder.Property(x => x.IdCartao)
                   .IsRequired();

            builder.Property(x => x.IdUsuario)
                   .IsRequired();

            builder.HasOne(x => x.Cartao)
                   .WithMany(x => x.UsuarioCartao)
                   .HasForeignKey(x => x.IdCartao)
                   .IsRequired();

            builder.HasOne(x => x.Usuario)
                   .WithMany(x => x.UsuarioCartoes)
                   .HasForeignKey(x => x.IdUsuario)
                   .OnDelete(DeleteBehavior.Cascade)
                   .IsRequired();
        }
    }
}
