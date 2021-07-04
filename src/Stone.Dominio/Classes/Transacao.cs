using System;

namespace Stone.Dominio.Classes
{
    /// <summary>
    /// Classe responsável por uma transação
    /// </summary>
    public class Transacao
    {
        /// <summary>
        /// Identificador do Usuário
        /// </summary>
        public Guid IdUsuario { get; private set; }

        /// <summary>
        /// Identificador do Aplicativo
        /// </summary>
        public Guid IdAplicativo { get; private set; }

        /// <summary>
        /// Identificador do Cartão
        /// </summary>
        public Guid IdCartao { get; private set; }

        /// <summary>
        /// Usuário
        /// </summary>
        public Usuario Usuario { get; private set; }

        /// <summary>
        /// Aplicativo
        /// </summary>
        public Aplicativo Aplicativo { get; private set; }

        /// <summary>
        /// Cartão
        /// </summary>
        public Cartao Cartao { get; private set; }
    }
}
