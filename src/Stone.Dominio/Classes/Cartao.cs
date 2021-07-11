using Stone.Dominio.Classes.Base;
using Stone.Dominio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Usuário
        /// </summary>
        public IList<UsuarioCartao> UsuarioCartao { get; private set; }

        /// <summary>
        /// Transações que o cartão foi utilizado
        /// </summary>
        public IList<Transacao> Transacoes { get; private set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Cartao()
        {

        }
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="id">id</param>
        public Cartao(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Método para criar uma entidade cartão
        /// </summary>
        /// <param name="cartao">Cartão DTO</param>
        /// <returns>Cartão Model</returns>
        public static Cartao Create(CartaoDTO cartao) => new()
        {
            Bandeira = cartao.Bandeira,
            NomeDoTitular = cartao.NomeDoTitular,
            Numero = cartao.Numero,
            Validade = cartao.Validade,
            CodigoDeSeguranca = cartao.CodigoDeSeguranca,
            Id = cartao.Id == null ? Guid.NewGuid() : cartao.Id.Value
        };

        /// <summary>
        /// Método para criar uma entidade cartão
        /// </summary>
        /// <param name="cartao">Adicionar Cartão DTO</param>
        /// <returns>Cartão Model</returns>
        public static Cartao Create(AdicionarCartaoDTO cartao) => new()
        {
            Bandeira = cartao.Bandeira,
            NomeDoTitular = cartao.NomeDoTitular,
            Numero = cartao.Numero,
            Validade = cartao.Validade,
            CodigoDeSeguranca = cartao.CodigoDeSeguranca,
            Id = Guid.NewGuid(),
        };

        /// <summary>
        /// Método para associar cartão e usuário
        /// </summary>
        /// <param name="idDoCartao"></param>
        /// <param name="idDoUsuario"></param>
        public void AssociarUsuarioCartao(Guid idDoCartao, Guid idDoUsuario)
        {
            if (UsuarioCartao == null || !UsuarioCartao.Any())
                UsuarioCartao = new List<UsuarioCartao>();

            UsuarioCartao.Add(Classes.UsuarioCartao.Create(idDoUsuario, idDoCartao));
        }
    }
}
