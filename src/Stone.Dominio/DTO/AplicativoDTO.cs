using System;
using System.Collections.Generic;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe DTO responsável pelo aplicativo
    /// </summary>
    public class AplicativoDTO
    {
        /// <summary>
        /// Identificador do Aplicativo
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Nome do Aplicativo
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Valor do aplicativo
        /// </summary>
        public decimal Valor { get; set; }

        /// <summary>
        /// Lista de transações em que o aplicativo está
        /// </summary>
        public IList<TransacaoDTO> Transacoes { get; set; }
    }
}
