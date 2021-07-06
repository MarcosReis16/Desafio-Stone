using Stone.Dominio.Classes;
using System.Threading.Tasks;

namespace Stone.Dominio.Interfaces
{
    /// <summary>
    /// Interface do repositório de transações
    /// </summary>
    public interface IRepositorioDeTransacoes
    {
        /// <summary>
        /// Método responsável por inserir uma transação
        /// </summary>
        /// <param name="transacao">Transação</param>
        /// <returns></returns>
        Task Adicionar(Transacao transacao);
        
    }
}
