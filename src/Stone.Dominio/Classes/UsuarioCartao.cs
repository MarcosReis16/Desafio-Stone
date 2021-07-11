using Stone.Dominio.DTO;
using System;

namespace Stone.Dominio.Classes
{
    /// <summary>
    /// Classe de relacionamento entre um usuário e o cartão
    /// </summary>
    public class UsuarioCartao
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public Guid IdUsuario { get; private set; }

        /// <summary>
        /// Id do cartão
        /// </summary>
        public Guid IdCartao { get; private set; }

        /// <summary>
        /// Usuário
        /// </summary>
        public Usuario Usuario { get; private set; }

        /// <summary>
        /// Cartão
        /// </summary>
        public Cartao Cartao { get; private set; }

        /// <summary>
        /// Método de criação de uma relação cartão usuário
        /// </summary>
        /// <param name="idUsuario">Id do usuário</param>
        /// <param name="idCartao">Id do cartão</param>
        /// <returns></returns>
        public static UsuarioCartao Create(Guid idUsuario, Guid idCartao) => new()
        {
            IdUsuario = idUsuario,
            IdCartao = idCartao,
        };
    }
}
