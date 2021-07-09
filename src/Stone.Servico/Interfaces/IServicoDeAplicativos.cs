using Stone.Dominio.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Servico.Interfaces
{
    /// <summary>
    /// Interface do serviço de aplicativos
    /// </summary>
    public interface IServicoDeAplicativos
    {
        /// <summary>
        /// Obter Todos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AplicativoDTO>> ObterTodos();
    }
}
