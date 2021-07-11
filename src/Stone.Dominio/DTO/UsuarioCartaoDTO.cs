using System;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe Usuario Cartão
    /// </summary>
    public class UsuarioCartaoDTO
    {
        /// <summary>
        /// Id do usuário
        /// </summary>
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Id do cartão
        /// </summary>
        public Guid IdCartao { get; set; }
    }
}
