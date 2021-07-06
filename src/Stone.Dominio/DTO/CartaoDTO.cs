using System;
using System.Collections.Generic;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe DTO responsável pelo cartão
    /// </summary>
    public class CartaoDTO
    {
        /// <summary>
        /// Identificador do Cartão
        /// </summary>
        public Guid? Id { get; set; }

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

        /// <summary>
        /// Usuário
        /// </summary>
        public UsuarioPersonalizadoDTO Usuario { get; set; }

        /// <summary>
        /// Transações que o cartão foi utilizado
        /// </summary>
        public IList<TransacaoDTO> Transacoes { get; set; }

        /// <summary>
        /// Confirmação se o cartão será salvo na base de dados
        /// </summary>
        public bool SalvarCartao { get; set; }
    }
}
