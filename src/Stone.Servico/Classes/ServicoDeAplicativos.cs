using AutoMapper;
using Microsoft.Extensions.Logging;
using Stone.Dominio.DTO;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Servico.Base;
using Stone.Servico.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Servico.Classes
{
    /// <summary>
    /// Serviço de Aplicativos
    /// </summary>
    public class ServicoDeAplicativos : ServicoBase, IServicoDeAplicativos
    {
        /// <summary>
        /// Instância de um repositório de Aplicativo
        /// </summary>
        private readonly IRepositorioDeAplicativos _repositorioDeAplicativos;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorioDeAplicativos">Instância de um repositório de Aplicativos</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="logger">Logger</param>
        public ServicoDeAplicativos(IRepositorioDeAplicativos repositorioDeAplicativos,
                                    IMapper mapper, ILogger<ServicoDeAplicativos> logger) : base (mapper, logger)
        {
            _repositorioDeAplicativos = repositorioDeAplicativos;
        }

        /// <summary>
        /// Obter Todos
        /// </summary>
        /// <returns>Lista de aplicativos</returns>
        public async Task<IEnumerable<AplicativoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<AplicativoDTO>>(await _repositorioDeAplicativos.ObterTodos());
        }
    }
}
