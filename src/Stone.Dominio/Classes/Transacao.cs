using Stone.Dominio.DTO;
using Stone.Dominio.Enums;
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
        /// Status da Transação
        /// </summary>
        public int StatusDaTransacao { get; private set; }

        /// <summary>
        /// Construtor
        /// </summary>
        public Transacao()
        {

        }

        /// <summary>
        /// Método para criar uma transação
        /// </summary>
        /// <param name="transacao">Adicionar Transação</param>
        /// <param name="usuario">Usuario</param>
        /// <param name="cartao">Cartao</param>
        /// <returns>Transação</returns>
        public Transacao (AdicionarTransacaoDTO transacao, Usuario usuario, Cartao cartao)
        {
            IdUsuario = usuario.Id;
            IdAplicativo = transacao.IdAplicativo.Value;
            IdCartao = cartao.Id;
            StatusDaTransacao = (int)EStatusDaTransacao.AguardandoProcessamento;

            if (transacao.SalvarCartao.Value)
            {
                Cartao = cartao;
                Cartao.AssociarUsuarioCartao(IdCartao, IdUsuario);
            }
        }

        /// <summary>
        /// Método para alterar o status da transação
        /// </summary>
        /// <param name="status">Status da transação</param>
        public void AlterarStatusDaTransacao(EStatusDaTransacao status)
        {
            StatusDaTransacao = (int)status;
        }
    }
}
