using Stone.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Servico.Interfaces
{
    /// <summary>
    /// Interface do serviço de cartão
    /// </summary>
    public interface IServicoDeCartao
    {
        /// <summary>
        /// Obter todos os cartões
        /// </summary>
        /// <returns>Lista de cartões</returns>
        Task<IEnumerable<CartaoDTO>> ObterTodos();

        /// <summary>
        /// Obter por id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Cartão DTO</returns>
        Task<CartaoDTO> ObterPorId(Guid id);
    }
}
