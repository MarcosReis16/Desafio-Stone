using AutoMapper;

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
        /// Construtor
        /// </summary>
        /// <param name="mapper">Instância do mapeador</param>
        protected ServicoBase(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
