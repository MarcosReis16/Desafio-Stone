using Microsoft.AspNetCore.Identity;
using Stone.Dominio.DTO;
using System.Threading.Tasks;

namespace Stone.Servico.Interfaces
{
    /// <summary>
    /// Interface do serviço de autenticação
    /// </summary>
    public interface IServicoDeAuth
    {
        /// <summary>
        /// Método responsável por registrar um usuário
        /// </summary>
        /// <param name="usuarioDeRegistro">Usuário para registro</param>
        /// <param name="password">Senha</param>
        /// <returns>Identity Result</returns>
        Task<IdentityResult> Registrar(UsuarioPersonalizadoDTO usuarioDeRegistro, string password);

        /// <summary>
        /// Método responsável por logar um usuário
        /// </summary>
        /// <param name="usuarioDeLogin">Usuário</param>
        /// <returns>Resultado de Login</returns>
        Task<SignInResult> Login(UsuarioDeLoginDTO usuarioDeLogin);

        /// <summary>
        /// Método responsável por logar um usuário sem autenticação
        /// </summary>
        /// <param name="usuario">Usuário</param>
        /// <returns>Usuário do Identity</returns>
        Task LogarUsuario(UsuarioPersonalizadoDTO usuario);

        /// <summary>
        /// Método responsável para gerar o Token JWT
        /// </summary>
        /// <param name="email">Email do usuário</param>
        /// <returns>Modelo de resposta do login</returns>
        Task<RespostaDoLoginDTO> GerarJwt(string email);


    }
}
