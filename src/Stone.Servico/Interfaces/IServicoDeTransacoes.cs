using Stone.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Servico.Interfaces
{
    /// <summary>
    /// Interface do Serviço de Transações
    /// </summary>
    public interface IServicoDeTransacoes
    {
        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="transacao">Adicionar Transação DTO</param>
        /// <returns>Confirmação</returns>
        Task<bool> Adicionar(AdicionarTransacaoDTO transacao);

        /// <summary>
        /// Obter Todos
        /// </summary>
        /// <returns>Lista de Transações DTO</returns>
        Task<IEnumerable<TransacaoDTO>> ObterTodos();

        /// <summary>
        /// Obter por Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Transacao</returns>
        Task<TransacaoDTO> ObterPorId(Guid id);
    }
}
