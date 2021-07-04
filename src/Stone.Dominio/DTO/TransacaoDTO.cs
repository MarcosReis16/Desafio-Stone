using System;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe DTO responsável por uma transação
    /// </summary>
    public class TransacaoDTO
    {
        /// <summary>
        /// Usuário
        /// </summary>
        public UsuarioDTO Usuario { get; set; }

        /// <summary>
        /// Aplicativo
        /// </summary>
        public AplicativoDTO Aplicativo { get; set; }

        /// <summary>
        /// Cartão
        /// </summary>
        public CartaoDTO Cartao { get; set; }
    }
}
