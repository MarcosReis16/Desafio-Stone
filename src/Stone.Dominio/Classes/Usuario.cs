using Microsoft.AspNetCore.Identity;
using System;

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
        /// Construtor padrão
        /// </summary>
        public Usuario()
        {
            Id = Guid.NewGuid();
        }

    }
}
