using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stone.Dominio.InterfacesDosRepositorios
{
    /// <summary>
    /// Interface de repositório genérica
    /// </summary>
    /// <typeparam name="TEntity">Classe genérica</typeparam>
    public interface IRepositorio<TEntity> : IDisposable where TEntity : class
    {
        /// <summary>
        /// Método genérico de adicionar uma entidade
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        /// <returns>Confirmação</returns>
        Task<bool> Adicionar(TEntity entity);

        /// <summary>
        /// Método genérico responsável por obter uma entidade por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Entidade</returns>
        Task<TEntity> ObterPorId(Guid id);

        /// <summary>
        /// Método genérico responsável por obter uma lista com todas as entidades
        /// </summary>
        /// <returns>Lista de entidades</returns>
        Task<IEnumerable<TEntity>> ObterTodos();

        /// <summary>
        /// Método genérico responsável por atualizar uma entidade
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        /// <returns>Confirmação</returns>
        Task<bool> Atualizar(TEntity entity);

        /// <summary>
        /// Método genérico responsável por remover uma entidade
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Confirmação</returns>
        Task<bool> Remover(Guid id);

        /// <summary>
        /// Método responsável por retornar uma entidade através de lambda expression
        /// </summary>
        /// <param name="predicate">Expressão lambda</param>
        /// <returns>Lista de Entidades</returns>
        Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Método responsável por salvar alterações
        /// </summary>
        /// <returns>Confirmação</returns>
        Task<bool> SaveChanges();
    }
}
