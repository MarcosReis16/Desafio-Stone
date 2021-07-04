using Stone.Dominio.Classes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stone.Dominio.InterfacesDosRepositorios
{
    /// <summary>
    /// Interface de repositório do usuário
    /// </summary>
    public interface IRepositorioDeUsuario
    {
        /// <summary>
        /// Método para adicionar um usuário
        /// </summary>
        /// <param name="usuario">Usuário</param>
        /// <returns></returns>
        Task Adicionar(Usuario usuario);

        /// <summary>
        /// Método responsável por obter um usuário por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Usuário</returns>
        Task<Usuario> ObterPorId(Guid id);

        /// <summary>
        /// Método responsável por obter um usuário com seu endereço e suas compras por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Usuário com Endereço e Compras</returns>
        Task<Usuario> ObterUsuarioEnderecoTransacoesCartoesPorId(Guid id);

        /// <summary>
        /// Método responsável por obter uma lista com todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        Task<IEnumerable<Usuario>> ObterTodos();

        /// <summary>
        /// Método responsável por atualizar um usuário
        /// </summary>
        /// <param name="entity">Usuário</param>
        /// <returns></returns>
        Task Atualizar(Usuario entity);

        /// <summary>
        /// Método responsável por remover um usuário
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns></returns>
        Task Remover(Guid id);

        /// <summary>
        /// Método responsável por retornar uma entidade através de lambda expression
        /// </summary>
        /// <param name="predicate">Expressão lambda</param>
        /// <returns>Lista de Usuários</returns>
        Task<IEnumerable<Usuario>> Buscar(Expression<Func<Usuario, bool>> predicate);
    }
}
