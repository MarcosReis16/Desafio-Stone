using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stone.Dominio.Classes;
using Stone.Dominio.DTO;
using Stone.Dominio.Excecoes;
using Stone.Servico.Base;
using Stone.Servico.Extensoes;
using Stone.Servico.Interfaces;
using Stone.Utilitarios.Mensagens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stone.Servico.Classes
{
    /// <summary>
    /// Classe de serviço de autenticação
    /// </summary>
    public class ServicoDeAuth : ServicoBase, IServicoDeAuth
    {
        /// <summary>
        /// Administrador de login
        /// </summary>
        private readonly SignInManager<Usuario> _signInManager;

        /// <summary>
        /// Administrador de usuário
        /// </summary>
        private readonly UserManager<Usuario> _userManager;

        /// <summary>
        /// Instância de um objeto App Settings
        /// </summary>
        private readonly AppSettings _appSettings;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="signInManager">Sign In Manager</param>
        /// <param name="userManager">User Manager</param>
        /// <param name="appSettings">App Settings</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="logger">Logger</param>
        public ServicoDeAuth(SignInManager<Usuario> signInManager,
                              UserManager<Usuario> userManager,
                              IOptions<AppSettings> appSettings,
                              IMapper mapper,
                              ILogger<ServicoDeAuth> logger) : base (mapper, logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Método responsável por registrar um usuário
        /// </summary>
        /// <param name="usuarioDeRegistro">Usuário para registro</param>
        /// <returns>Objeto de Resposta</returns>
        public async Task<RespostaDoLoginDTO> Registrar(UsuarioDeRegistroDTO usuarioDeRegistro)
        {
            var result = await _userManager.CreateAsync(Usuario.Create(usuarioDeRegistro), usuarioDeRegistro.Password);
            VerificarErros(result);
            _logger.LogInformation(Mensagens.RegistroComSucesso);
            return await GerarJwt(usuarioDeRegistro.Email);
        }

        /// <summary>
        /// Método responsável por logar um usuário
        /// </summary>
        /// <param name="usuarioDeLogin">Usuário</param>
        /// <returns>Resultado de Login</returns>
        public async Task<RespostaDoLoginDTO> Login(UsuarioDeLoginDTO usuarioDeLogin)
        {
            var result = await _signInManager.PasswordSignInAsync(usuarioDeLogin.Email, usuarioDeLogin.Password, false, true);
            if (!result.Succeeded) throw new ExcecaoDeNegocio("Usuário ou Senha inválidos");
            _logger.LogInformation(Mensagens.LoginComSucesso);
            return await GerarJwt(usuarioDeLogin.Email);
        }

        /// <summary>
        /// Método responsável para gerar o Token JWT
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Modelo de resposta do login</returns>
        private async Task<RespostaDoLoginDTO> GerarJwt(string email)
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
            var response = new RespostaDoLoginDTO
            {
                TokenDeAcesso = encodedToken,
                TempoDeExpiracao = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                TokenDeUsuario = new TokenDeUsuarioDTO
                {
                    Id = user.Id.ToString(),
                    Email = user.Email,
                }
            };

            return response;
        }

        /// <summary>
        /// Método para verificar se existe erros no Identity Result
        /// </summary>
        /// <param name="result">Identity Result</param>
        private void VerificarErros(IdentityResult result)
        {
            if (!result.Succeeded)
                throw new ExcecaoDeValidacao(result.Errors.Select(e => e.Description).Distinct().ToList());
        }
    }
}
