using Microsoft.EntityFrameworkCore;
using Stone.Dominio.Classes;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Infraestrutura.Contextos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Stone.Infraestrutura.Repositorios
{
    /// <summary>
    /// Repositório responsável pelo usuário
    /// </summary>
    public class RepositorioDeUsuario : IRepositorioDeUsuario
    {
        /// <summary>
        /// Instância do repositório genérico
        /// </summary>
        private readonly IRepositorio<Usuario> _repositorio;

        /// <summary>
        /// Instância do contexto
        /// </summary>
        protected readonly MeuDbContext Db;

        /// <summary>
        /// Instância de um Dbset
        /// </summary>
        protected readonly DbSet<Usuario> DbSet;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorio">Instância do repositório genérico</param>
        public RepositorioDeUsuario(IRepositorio<Usuario> repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Método para adicionar um usuário
        /// </summary>
        /// <param name="usuario">Usuário</param>
        /// <returns></returns>
        public async Task Adicionar(Usuario usuario)
        {
            await _repositorio.Adicionar(usuario);
        }

        /// <summary>
        /// Método responsável por atualizar um usuário
        /// </summary>
        /// <param name="entity">Usuário</param>
        /// <returns></returns>
        public async Task Atualizar(Usuario usuario)
        {
            await _repositorio.Atualizar(usuario);
        }

        /// <summary>
        /// Método responsável por retornar uma entidade através de lambda expression
        /// </summary>
        /// <param name="predicate">Expressão lambda</param>
        /// <returns>Lista de Usuários</returns>
        public async Task<IEnumerable<Usuario>> Buscar(Expression<Func<Usuario, bool>> predicate)
        {
            return await _repositorio.Buscar(predicate);
        }

        /// <summary>
        /// Método responsável por obter um usuário por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Usuário</returns>
        public async Task<Usuario> ObterPorId(Guid id)
        {
            return await _repositorio.ObterPorId(id);
        }

        /// <summary>
        /// Método responsável por obter um usuário com seu endereço por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Usuário com Endereço</returns>
        public async Task<Usuario> ObterUsuarioEnderecoPorId(Guid id)
        {
            return await DbSet.AsNoTracking()
                              .Include(u => u.Endereco)
                              .FirstOrDefaultAsync(u => u.Id == id);
        }

        /// <summary>
        /// Método responsável por obter uma lista com todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _repositorio.ObterTodos();
        }

        /// <summary>
        /// Método responsável por remover um usuário
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            await _repositorio.Remover(id);
        }
    }
}
