using Stone.Dominio.DTO;
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

        /// <summary>
        /// Método para criar uma transação
        /// </summary>
        /// <param name="transacao">Adicionar Transação</param>
        /// <returns>Transação</returns>
        public static Transacao Create(AdicionarTransacaoDTO transacao) => new()
        {
            IdUsuario = transacao.IdUsuario,
            IdAplicativo = transacao.IdAplicativo,
            IdCartao = transacao.Cartao.Id == null ? Guid.Empty : transacao.Cartao.Id.Value,
            Cartao = transacao.Cartao.Id == null ? Cartao.Create(transacao.Cartao) : new Cartao(transacao.Cartao.Id.Value)
        };
    }
}
