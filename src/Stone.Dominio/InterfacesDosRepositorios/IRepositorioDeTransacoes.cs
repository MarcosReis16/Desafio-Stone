using Stone.Dominio.Classes;
using System;
using System.Threading.Tasks;

namespace Stone.Dominio.InterfacesDosRepositorios
{
    /// <summary>
    /// Interface do repositório de transações
    /// </summary>
    public interface IRepositorioDeTransacoes : IRepositorio<Transacao>
    {
        /// <summary>
        /// Método responsável por obter uma transação com seus objetos aninhados.
        /// </summary>
        /// <param name="idUsuario">Id do Usuário</param>
        /// <param name="idAplicativo">Id do Aplicativo</param>
        /// <returns>Transação</returns>
        Task<Transacao> ObterTransacaoAplicativoUsuarioCartao(Guid idUsuario, Guid idAplicativo);
    }
}
