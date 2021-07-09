using System;

namespace Stone.Dominio.DTO
{
    public class AdicionarTransacaoDTO
    {
        /// <summary>
        /// Identificador do Usuário
        /// </summary>
        public Guid IdUsuario { get; set; }

        /// <summary>
        /// Identificador do Aplicativo
        /// </summary>
        public Guid IdAplicativo { get; set; }

        /// <summary>
        /// Cartão
        /// </summary>
        public CartaoDTO Cartao { get; set; }
    }
}
