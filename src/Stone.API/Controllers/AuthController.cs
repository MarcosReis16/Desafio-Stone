using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stone.API.Controllers.Base;
using Stone.Dominio.DTO;
using Stone.Servico.Interfaces;
using Stone.Utilitarios.Filtros.Excecao;
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
        /// <param name="servicoDeAuth">Instância de um serviço de autenticação</param>
        public AuthController(IServicoDeAuth servicoDeAuth)
        {
            _servicoDeAuth = servicoDeAuth;
        }

        /// <summary>
        /// Endpoint responsável por registrar um usuário
        /// </summary>
        /// <param name="usuarioDeRegistro">Usuário de Registro</param>
        /// <returns>Custom Response</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status500InternalServerError)]
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioDeRegistroDTO usuarioDeRegistro)
        {
            return Created(nameof(Registrar),await _servicoDeAuth.Registrar(usuarioDeRegistro));
        }

        /// <summary>
        /// Endpoint responsável pelo login do usuário
        /// </summary>
        /// <param name="usuarioDeLogin">Usuário de Login</param>
        /// <returns>Resposta customizada com token JWT</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioDeLoginDTO usuarioDeLogin)
        {
            return Ok(await _servicoDeAuth.Login(usuarioDeLogin));
        }

    }
}
