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
        /// Construtor
        /// </summary>
        protected MainController()
        {

        }
    }
    
}
