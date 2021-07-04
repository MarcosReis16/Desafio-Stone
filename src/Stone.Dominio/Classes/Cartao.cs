using Stone.Dominio.Classes.Base;
using System;
using System.Collections.Generic;

namespace Stone.Dominio.Classes
{
    /// <summary>
    /// Entidade responsável pelo cartão
    /// </summary>
    public class Cartao : ModelBase
    {
        /// <summary>
        /// Bandeira
        /// </summary>
        public string Bandeira { get; private set; }

        /// <summary>
        /// Nome do Titular
        /// </summary>
        public string NomeDoTitular { get; private set; }

        /// <summary>
        /// Número do Cartão
        /// </summary>
        public string Numero { get; private set; }

        /// <summary>
        /// Validade do Cartão
        /// </summary>
        public string Validade { get; private set; }

        /// <summary>
        /// Código de Segurança
        /// </summary>
        public string CodigoDeSeguranca { get; private set; }

        /// <summary>
        /// Identificador do usuário
        /// </summary>
        public Guid IdUsuario { get; private set; }

        /// <summary>
        /// Usuário
        /// </summary>
        public Usuario Usuario { get; private set; }

        /// <summary>
        /// Transações que o cartão foi utilizado
        /// </summary>
        public IList<Transacao> Transacoes { get; private set; }


    }
}
