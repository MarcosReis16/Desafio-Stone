using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stone.API.Controllers.Base;
using Stone.API.Extensions;
using Stone.API.ViewModel;
using Stone.Dominio.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
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
        /// Instância de um objeto App Settings
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// instância de um objeto User Manager
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Instância de um objeto SignInManager
        /// </summary>
        private readonly SignInManager<IdentityUser> _signInManager;

        /// <summary>
        /// Instância de um objeto de Log
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="notificador">Instância de um notificador</param>
        /// <param name="signInManager">Instância de um SignInManager</param>
        /// <param name="userManager">Instância de User Manager</param>
        /// <param name="appSettings">Instância de um App settings</param>
        /// <param name="logger">Instância de um objeto de Log</param>
        public AuthController(INotificador notificador,
                              SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings,
                              ILogger logger) : base (notificador)
        {
            _appSettings = appSettings.Value;
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        /// <summary>
        /// Endpoint responsável por registrar um usuário
        /// </summary>
        /// <param name="usuarioDeRegistro">Usuário de Registro</param>
        /// <returns>Custom Response</returns>
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar(UsuarioDeRegistroViewModel usuarioDeRegistro)
        {
            UsuarioPersonalizadoViewModel user = new()
            {
                UserName = usuarioDeRegistro.Email,
                Email = usuarioDeRegistro.Email,
                EmailConfirmed = true,
                Nome = usuarioDeRegistro.Nome,
                Cpf = usuarioDeRegistro.Cpf,
                DataDeNascimento = usuarioDeRegistro.DataDeNascimento,
                Sexo = usuarioDeRegistro.Sexo,
            };

            var result = await _userManager.CreateAsync(user, usuarioDeRegistro.Password);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuário registrado com sucesso");
                await _signInManager.SignInAsync(user, false);
                return CustomResponse(await GerarJwt(user.Email));
            }
            foreach (var error in result.Errors)
            {
                NotificarErro(error.Description);
            }

            return CustomResponse(usuarioDeRegistro);

        }

        /// <summary>
        /// Endpoint responsável pelo login do usuário
        /// </summary>
        /// <param name="usuarioDeLogin">Usuário de Login</param>
        /// <returns>Resposta customizada com token JWT</returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UsuarioDeLoginViewModel usuarioDeLogin)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var result = await _signInManager.PasswordSignInAsync(usuarioDeLogin.Email, usuarioDeLogin.Password, false, true);

            if (result.Succeeded)
            {
                _logger.LogInformation("Usuario " + usuarioDeLogin.Email + " logado com sucesso");
                return CustomResponse(await GerarJwt(usuarioDeLogin.Email));
            }
            if (result.IsLockedOut)
            {
                NotificarErro("Usuário temporariamente bloqueado por tentativas inválidas");
                return CustomResponse(usuarioDeLogin);
            }

            NotificarErro("Usuário ou Senha incorretos");
            return CustomResponse(usuarioDeLogin);
        }

        /// <summary>
        /// Método responsável para gerar o Token JWT
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Modelo de resposta do login</returns>
        private async Task<RespostaDoLoginViewModel> GerarJwt(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new RespostaDoLoginViewModel
            {
                TokenDeAcesso = encodedToken,
                TempoDeExpiracao = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                TokenDeUsuario = new TokenDeUsuarioViewModel
                {
                    Id = user.Id,
                    Email = user.Email,
                }
            };

            return response;
        }
    }
}
