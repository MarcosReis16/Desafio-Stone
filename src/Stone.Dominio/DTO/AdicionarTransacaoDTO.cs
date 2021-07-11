using System;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe responsável por adicionar uma Transação
    /// </summary>
    public class AdicionarTransacaoDTO
    {
        /// <summary>
        /// Identificador do Aplicativo
        /// </summary>
        public Guid? IdAplicativo { get; set; }

        /// <summary>
        /// Identificador do Usuário
        /// </summary>
        public Guid? IdUsuario { get; set; }

        /// <summary>
        /// Identificador do Cartão
        /// </summary>
        public Guid? IdCartao { get; set; }

        /// <summary>
        /// Cartão
        /// </summary>
        public AdicionarCartaoDTO Cartao { get; set; }

        /// <summary>
        /// Salvar Cartão?
        /// </summary>
        public bool? SalvarCartao { get; set; }
    }
}
