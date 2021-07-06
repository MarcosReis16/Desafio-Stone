using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Stone.Dominio.DTO;
using Stone.Servico.Base;
using Stone.Servico.Extensoes;
using Stone.Servico.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
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
        private readonly SignInManager<IdentityUser> _signInManager;

        /// <summary>
        /// Administrador de usuário
        /// </summary>
        private readonly UserManager<IdentityUser> _userManager;

        /// <summary>
        /// Instância de um objeto App Settings
        /// </summary>
        private readonly AppSettings _appSettings;


        public ServicoDeAuth(SignInManager<IdentityUser> signInManager,
                              UserManager<IdentityUser> userManager,
                              IOptions<AppSettings> appSettings,
                              IMapper mapper) : base (mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Método responsável por registrar um usuário
        /// </summary>
        /// <param name="usuarioDeRegistro">Usuário para registro</param>
        /// <param name="password">Senha</param>
        /// <returns>Identity Result</returns>
        public async Task<IdentityResult> Registrar(UsuarioPersonalizadoDTO usuarioDeRegistro, string password)
        {
            return await _userManager.CreateAsync(usuarioDeRegistro, password);
        }

        /// <summary>
        /// Método responsável por logar um usuário
        /// </summary>
        /// <param name="usuarioDeLogin">Usuário</param>
        /// <returns>Resultado de Login</returns>
        public async Task<SignInResult> Login(UsuarioDeLoginDTO usuarioDeLogin)
        {
            return await _signInManager.PasswordSignInAsync(usuarioDeLogin.Email, usuarioDeLogin.Password, false, true);
        }

        /// <summary>
        /// Método responsável por logar um usuário sem autenticação
        /// </summary>
        /// <param name="usuario">Usuário</param>
        /// <returns>Usuário do Identity</returns>
        public async Task LogarUsuario(UsuarioPersonalizadoDTO usuario)
        {
            await _signInManager.SignInAsync(usuario, false);
        }

        /// <summary>
        /// Método responsável para gerar o Token JWT
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Modelo de resposta do login</returns>
        public async Task<RespostaDoLoginDTO> GerarJwt(string email)
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
                    Id = user.Id,
                    Email = user.Email,
                }
            };

            return response;
        }
    }
}
