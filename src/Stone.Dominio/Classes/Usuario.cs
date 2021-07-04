using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Stone.Dominio.Classes
{
    /// <summary>
    /// Classe responsável pelo usuário
    /// </summary>
    public class Usuario : IdentityUser<Guid>
    {
        /// <summary>
        /// Nome
        /// </summary>
        public string Nome { get; private set; }

        /// <summary>
        /// Cpf
        /// </summary>
        public string Cpf { get; private set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        public DateTime DataDeNascimento { get; private set; }

        /// <summary>
        /// Sexo
        /// </summary>
        public int Sexo { get; private set; }

        /// <summary>
        /// Endereco
        /// </summary>
        public Endereco Endereco { get; private set; }

        /// <summary>
        /// Transações efetuadas pelo usuário
        /// </summary>
        public IList<Transacao> Transacoes { get; private set; }

        /// <summary>
        /// Cartões salvos pelo usuário
        /// </summary>
        public IList<Cartao> Cartoes { get; private set; }

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public Usuario()
        {
            Id = Guid.NewGuid();
        }

    }
}
