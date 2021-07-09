using Microsoft.AspNetCore.Mvc;

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
