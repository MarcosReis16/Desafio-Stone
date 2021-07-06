using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stone.API.Controllers.Base;
using Stone.Dominio.DTO;
using Stone.Servico.Interfaces;
using System.Threading.Tasks;

namespace Stone.API.Controllers
{
    /// <summary>
    /// Controller de autenticação
    /// </summary>
    [Route("api/auth")]
    [ApiController]
    public class AuthController : MainController
    {
        /// <summary>
        /// Instância do serviço de autenticação
        /// </summary>
        private readonly IServicoDeAuth _servicoDeAuth;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="notificador">Instância de um notificador</param>
        /// <param name="logger">Instância de um objeto de Log</param>
        /// <param name="servicoDeAuth">Instância de um serviço de autenticação</param>
        public AuthController(ILogger logger,
                              IServicoDeAuth servicoDeAuth) : base (logger)
        {
            _servicoDeAuth = servicoDeAuth;
        }

        /// <summary>
        /// Endpoint responsável por registrar um usuário
        /// </summary>
        /// <param name="usuarioDeRegistro">Usuário de Registro</param>
        /// <returns>Custom Response</returns>
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioDeRegistroDTO usuarioDeRegistro)
        {
            return Ok(await _servicoDeAuth.Registrar(usuarioDeRegistro));
        }

        /// <summary>
        /// Endpoint responsável pelo login do usuário
        /// </summary>
        /// <param name="usuarioDeLogin">Usuário de Login</param>
        /// <returns>Resposta customizada com token JWT</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioDeLoginDTO usuarioDeLogin)
        {
            return Ok(await _servicoDeAuth.Login(usuarioDeLogin));
        }

    }
}
