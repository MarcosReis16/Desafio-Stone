using System;
using System.ComponentModel.DataAnnotations;

namespace Stone.API.ViewModel
{
    /// <summary>
    /// Classe responsável por um registro de usuário
    /// </summary>
    public class UsuarioDeRegistroViewModel
    {
        /// <summary>
        /// Email
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
        public string Email { get; set; }

        /// <summary>
        /// Senha
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }

        /// <summary>
        /// Confirmação de senha
        /// </summary>
        [Compare("Password", ErrorMessage = "As senhas não conferem.")]
        public string ConfirmPassword { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        /// <summary>
        /// Cpf
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string Cpf { get; set; }

        /// <summary>
        /// Data de Nascimento
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataDeNascimento { get; set; }

        /// <summary>
        /// Sexo
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Sexo { get; set; }
    }
}
