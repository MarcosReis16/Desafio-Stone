using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Stone.Servico.Base
{
    /// <summary>
    /// Serviço base
    /// </summary>
    public abstract class ServicoBase
    {
        /// <summary>
        /// Instância do mapeador
        /// </summary>
        protected readonly IMapper _mapper;

        /// <summary>
        /// Instância do Logger
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mapper">Instância do mapeador</param>
        /// <param name="logger">Instância do Logger</param>
        protected ServicoBase(IMapper mapper,
                              ILogger logger)
        {
            _mapper = mapper;
            _logger = logger;
        }
    }
}
