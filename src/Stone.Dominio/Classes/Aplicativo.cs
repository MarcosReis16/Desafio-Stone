using Stone.Dominio.Classes.Base;
using System.Collections.Generic;

namespace Stone.Dominio.Classes
{
    /// <summary>
    /// Classe responsável pelo aplicativo
    /// </summary>
    public class Aplicativo : ModelBase
    {
        /// <summary>
        /// Nome do Aplicativo
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Valor do aplicativo
        /// </summary>
        public decimal Valor { get; private set; }

        /// <summary>
        /// Lista de transações em que o aplicativo está
        /// </summary>
        public IList<Transacao> Transacoes { get; private set; }
    }
}
