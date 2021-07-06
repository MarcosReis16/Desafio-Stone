using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stone.API.Controllers.Base;
using Stone.Dominio.DTO;
using Stone.Dominio.Interfaces;
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
        public AuthController(INotificador notificador,
                              ILogger logger,
                              IServicoDeAuth servicoDeAuth) : base (notificador, logger)
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
            UsuarioPersonalizadoDTO user = new()
            {
                UserName = usuarioDeRegistro.Email,
                Email = usuarioDeRegistro.Email,
                EmailConfirmed = true,
                Nome = usuarioDeRegistro.Nome,
                Cpf = usuarioDeRegistro.Cpf,
                DataDeNascimento = usuarioDeRegistro.DataDeNascimento,
                Sexo = usuarioDeRegistro.Sexo,
            };

            var result = await _servicoDeAuth.Registrar(user, usuarioDeRegistro.Password);
            return await ConfirmacaoDeRegistro(usuarioDeRegistro, user, result);
        }

        /// <summary>
        /// Endpoint responsável pelo login do usuário
        /// </summary>
        /// <param name="usuarioDeLogin">Usuário de Login</param>
        /// <returns>Resposta customizada com token JWT</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioDeLoginDTO usuarioDeLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _servicoDeAuth.Login(usuarioDeLogin);
            return await ConfirmacaoDeLogin(usuarioDeLogin, result);
        }

        /// <summary>
        /// Método para confirmar se o retorno do Identity para o registro foi positivo ou houve erros
        /// </summary>
        /// <param name="usuarioDeRegistro">Usuário de registro</param>
        /// <param name="user">Usuário Identity</param>
        /// <param name="result">Resultado do Identity</param>
        /// <returns>Custon Response</returns>
        private async Task<IActionResult> ConfirmacaoDeRegistro(UsuarioDeRegistroDTO usuarioDeRegistro, UsuarioPersonalizadoDTO user, IdentityResult result)
        {
            if (result.Succeeded)
            {
                _logger.LogInformation("Usuário registrado com sucesso");
                await _servicoDeAuth.LogarUsuario(user);
                return CustomResponse(await _servicoDeAuth.GerarJwt(user.Email));
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(usuarioDeRegistro);
        }

        /// <summary>
        /// Método para confirmar o retorno do Identity para o Login
        /// </summary>
        /// <param name="usuarioDeLogin">Usuario de Login</param>
        /// <param name="result">Resultado de Login</param>
        /// <returns>Custom Response</returns>
        private async Task<IActionResult> ConfirmacaoDeLogin(UsuarioDeLoginDTO usuarioDeLogin, Microsoft.AspNetCore.Identity.SignInResult result)
        {
            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario " + usuarioDeLogin.Email + " logado com sucesso");
                return CustomResponse(await _servicoDeAuth.GerarJwt(usuarioDeLogin.Email));
            }
            if (result.IsLockedOut)
            {
                _logger.LogInformation("Usuário temporariamente bloqueado por tentativas inválidas");
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(usuarioDeLogin);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(usuarioDeLogin);
        }

    }
}
