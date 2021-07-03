using AutoMapper;
using Stone.Servico.AutoMapper;

namespace Stone.API.Configuration
{
    /// <summary>
    /// Classe responsável por configurar o auto mapper
    /// </summary>
    public class AutoMapperConfig : Profile
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AutoMapperConfig()
        {
            this.Map();
        }
    }
}
