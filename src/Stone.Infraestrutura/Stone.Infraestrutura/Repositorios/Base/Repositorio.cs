using Microsoft.EntityFrameworkCore;
using Stone.Dominio.Excecoes;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Infraestrutura.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stone.Infraestrutura.Repositorios.Base
{
    /// <summary>
    /// Repositório genérico
    /// </summary>
    /// <typeparam name="TEntity">Entidade genérica</typeparam>
    public abstract class Repositorio<TEntity> : IRepositorio<TEntity> where TEntity : class
    {
        /// <summary>
        /// Instância do contexto
        /// </summary>
        protected readonly MeuDbContext Db;

        /// <summary>
        /// Instância de um Dbset
        /// </summary>
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db">Contexto</param>
        protected Repositorio(MeuDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        /// <summary>
        /// Método responsável por retornar uma entidade através de lambda expression
        /// </summary>
        /// <param name="predicate">Expressão lambda</param>
        /// <returns>Lista de Entidades</returns>
        public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await DbSet.Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ExcecaoDeErroInterno(ex);
            }
        }

        /// <summary>
        /// Método genérico responsável por obter uma entidade por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Entidade</returns>
        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            try
            {
                return await DbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new ExcecaoDeErroInterno(ex);
            }
        }

        /// <summary>
        /// Método genérico responsável por obter uma lista com todas as entidades
        /// </summary>
        /// <returns>Lista de entidades</returns>
        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            try
            {
                return await DbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new ExcecaoDeErroInterno(ex);
            }
        }

        /// <summary>
        /// Método genérico de adicionar uma entidade
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        /// <returns></returns>
        public virtual async Task<bool> Adicionar(TEntity entity)
        {
            try
            {
                await DbSet.AddAsync(entity);
                return await SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ExcecaoDeErroInterno(ex);
            }
        }

        /// <summary>
        /// Método genérico responsável por atualizar uma entidade
        /// </summary>
        /// <param name="entity">Entidade genérica</param>
        /// <returns></returns>
        public virtual async Task<bool> Atualizar(TEntity entity)
        {
            try
            {
                DbSet.Update(entity);
                return await SaveChanges();
            }
            catch (Exception ex)
            {
                throw new ExcecaoDeErroInterno(ex);
            }
        }

        /// <summary>
        /// Método genérico responsável por remover uma entidade
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns></returns>
        public virtual async Task<bool> Remover(Guid id)
        {
            try
            {
                TEntity entity = await DbSet.FindAsync(id);
                if (entity != null)
                {
                    DbSet.Remove(entity);
                    return await SaveChanges();
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new ExcecaoDeErroInterno(ex);
            }
        }

        /// <summary>
        /// Método responsável por salvar alterações
        /// </summary>
        /// <returns>Confirmação</returns>
        public virtual async Task<bool> SaveChanges()
        {
            try
            {
                return await Db.SaveChangesAsync() > 0;
            }
            catch (Exception ex)
            {
                throw new ExcecaoDeErroInterno(ex);
            }
        }
        
        /// <summary>
        /// Método responsável por dar dispose em objetos
        /// </summary>
        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
