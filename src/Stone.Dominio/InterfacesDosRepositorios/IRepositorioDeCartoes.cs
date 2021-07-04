using Stone.Dominio.Classes;
using System;
using System.Threading.Tasks;

namespace Stone.Dominio.InterfacesDosRepositorios
{
    /// <summary>
    /// Interface de repositório de cartões
    /// </summary>
    public interface IRepositorioDeCartoes
    {
        /// <summary>
        /// Método responsável por adicionar um cartão na base
        /// </summary>
        /// <param name="cartao">Cartão</param>
        /// <returns></returns>
        Task Adicionar(Cartao cartao);

        /// <summary>
        /// Método responsável por apagar um cartão da base
        /// </summary>
        /// <param name="id">Identificador do cartão</param>
        /// <returns></returns>
        Task Excluir(Guid id);
    }
}
