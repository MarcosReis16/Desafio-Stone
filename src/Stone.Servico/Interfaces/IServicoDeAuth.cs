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
        /// <returns>Objeto de Resposta</returns>
        Task<RespostaDoLoginDTO> Registrar(UsuarioDeRegistroDTO usuarioDeRegistro);

        /// <summary>
        /// Método responsável por logar um usuário
        /// </summary>
        /// <param name="usuarioDeLogin">Usuário</param>
        /// <returns>Resultado de Login</returns>
        Task<RespostaDoLoginDTO> Login(UsuarioDeLoginDTO usuarioDeLogin);

    }
}
