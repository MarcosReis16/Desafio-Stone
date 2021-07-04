using Stone.Dominio.Classes;
using Stone.Dominio.InterfacesDosRepositorios;
using System;
using System.Threading.Tasks;

namespace Stone.Infraestrutura.Repositorios
{
    /// <summary>
    /// Repositório da entidade cartão
    /// </summary>
    public class RepositorioDeCartoes : IRepositorioDeCartoes
    {
        /// <summary>
        /// Instância do repositório genérico para cartão
        /// </summary>
        private readonly IRepositorio<Cartao> _repositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorio">Instância do repositório genérico para cartão</param>
        public RepositorioDeCartoes(IRepositorio<Cartao> repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Método responsável por adicionar um cartão na base
        /// </summary>
        /// <param name="cartao">Cartão</param>
        /// <returns></returns>
        public async Task Adicionar(Cartao cartao)
        {
            await _repositorio.Adicionar(cartao);
        }

        /// <summary>
        /// Método responsável por apagar um cartão da base
        /// </summary>
        /// <param name="id">Identificador do cartão</param>
        /// <returns></returns>
        public async Task Excluir(Guid id)
        {
            await _repositorio.Remover(id);
        }
    }
}
