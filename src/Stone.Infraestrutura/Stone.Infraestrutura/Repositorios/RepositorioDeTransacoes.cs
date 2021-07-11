using Microsoft.EntityFrameworkCore;
using Stone.Dominio.Classes;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Infraestrutura.Contextos;
using Stone.Infraestrutura.Repositorios.Base;
using System;
using System.Threading.Tasks;

namespace Stone.Infraestrutura.Repositorios
{
    /// <summary>
    /// Repositório de transações
    /// </summary>
    public class RepositorioDeTransacoes : Repositorio<Transacao>, IRepositorioDeTransacoes
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public RepositorioDeTransacoes(MeuDbContext db) : base (db)
        {

        }

        /// <summary>
        /// Método responsável por obter uma transação com seus objetos aninhados.
        /// </summary>
        /// <param name="idUsuario">Id do Usuário</param>
        /// <param name="idAplicativo">Id do Aplicativo</param>
        /// <returns>Transação</returns>
        public async Task<Transacao> ObterTransacaoAplicativoUsuarioCartao(Guid idUsuario, Guid idAplicativo)
        {
            return await DbSet.Include(t => t.Aplicativo)
                              .Include(t => t.Usuario)
                              .Include(t => t.Cartao)
                              .FirstOrDefaultAsync(t => t.IdUsuario == idUsuario &&
                                                   t.IdAplicativo == idAplicativo);
        }
    }
}
