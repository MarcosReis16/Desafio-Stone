using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Stone.Dominio.Classes;

namespace Stone.Infraestrutura.Mapeamentos
{
    /// <summary>
    /// Classe de mapeamento de Transacao
    /// </summary>
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        /// <summary>
        /// Configuração
        /// </summary>
        /// <param name="builder">Construtor</param>
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(v => new { v.IdUsuario, v.IdAplicativo, v.IdCartao });

            builder.HasOne(v => v.Aplicativo)
                   .WithMany(v => v.Transacoes)
                   .HasForeignKey(v => v.IdAplicativo);

            builder.HasOne(v => v.Usuario)
                   .WithMany(v => v.Transacoes)
                   .HasForeignKey(v => v.IdUsuario);

            builder.HasOne(v => v.Cartao)
                   .WithMany(v => v.Transacoes)
                   .HasForeignKey(v => v.IdCartao);

        }
    }
}
