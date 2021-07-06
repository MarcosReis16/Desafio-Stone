using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Stone.API.Controllers.Base
{
    /// <summary>
    /// Controller base
    /// </summary>
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        /// <summary>
        /// Instância de um objeto de Log
        /// </summary>
        protected readonly ILogger _logger;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger">Instância de um Logger</param>
        protected MainController(ILogger logger)
        {
            _logger = logger;
        }
    }
    
}
