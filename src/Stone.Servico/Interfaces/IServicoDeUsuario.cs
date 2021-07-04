using Stone.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Servico.Interfaces
{
    public interface IServicoDeUsuario
    {
        /// <summary>
        /// Método para adicionar um usuário
        /// </summary>
        /// <param name="usuario">Usuário</param>
        /// <returns></returns>
        Task Adicionar(UsuarioDTO usuario);

        /// <summary>
        /// Método responsável por obter um usuário por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Usuário</returns>
        Task<UsuarioDTO> ObterPorId(Guid id);

        /// <summary>
        /// Método responsável por obter um usuário com seu endereço, transações e cartões salvos através do Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Usuário com Endereço, Transações e Cartões</returns>
        Task<UsuarioDTO> ObterUsuarioEnderecoTransacoesCartoesPorId(Guid id);

        /// <summary>
        /// Método responsável por obter uma lista com todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        Task<IEnumerable<UsuarioDTO>> ObterTodos();

        /// <summary>
        /// Método responsável por atualizar um usuário
        /// </summary>
        /// <param name="entity">Usuário</param>
        /// <returns></returns>
        Task Atualizar(UsuarioDTO usuario);

        /// <summary>
        /// Método responsável por remover um usuário
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns></returns>
        Task Remover(Guid id);
    }
}
