using System;
using System.Collections.Generic;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe do usuário personalizada
    /// </summary>
    public class UsuarioDTO
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid? Id { get; set; }

        /// <summary>
        /// Nome de usuário
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Email Confirmado
        /// </summary>
        public bool EmailConfirmed { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Cpf
        /// </summary>
        public string Cpf { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime DataDeNascimento { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        public int Sexo { get; set; }

        /// <summary>
        /// Endereço
        /// </summary>
        public EnderecoDTO Endereco { get; set; }

        /// <summary>
        /// Cartões
        /// </summary>
        public IList<CartaoDTO> Cartoes { get; set; }

        /// <summary>
        /// Transações
        /// </summary>
        public IList<TransacaoDTO> Transacoes { get; set; }

    }
}
