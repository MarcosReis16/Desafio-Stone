using System;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe responsável por adicionar o cartão
    /// </summary>
    public class AdicionarCartaoDTO
    {
        /// <summary>
        /// Bandeira
        /// </summary>
        public string Bandeira { get; set; }

        /// <summary>
        /// Nome do Titular
        /// </summary>
        public string NomeDoTitular { get; set; }

        /// <summary>
        /// Número do Cartão
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Validade do Cartão
        /// </summary>
        public string Validade { get; set; }

        /// <summary>
        /// Código de Segurança
        /// </summary>
        public string CodigoDeSeguranca { get; set; }
    }
}
