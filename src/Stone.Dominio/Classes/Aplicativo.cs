using Stone.Dominio.Classes.Base;
using System;
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

        /// <summary>
        /// Método create
        /// </summary>
        /// <param name="id">Identificador do aplicativo</param>
        /// <param name="nome">Nome do aplicativo</param>
        /// <param name="valor">Valor do aplicativo</param>
        /// <returns></returns>
        public static Aplicativo Create(Guid id, string nome, decimal valor) => new()
        {
            Id = id,
            Nome = nome,
            Valor = valor
        };
    }
}
