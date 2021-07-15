using System;
using System.ComponentModel.DataAnnotations;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Classe responsável por um registro de usuário
    /// </summary>
    public class UsuarioDeRegistroDTO
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Confirmação de senha
        /// </summary>
        public string ConfirmPassword { get; set; }

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

        public EnderecoDTO Endereco { get; set; }
    }
}
