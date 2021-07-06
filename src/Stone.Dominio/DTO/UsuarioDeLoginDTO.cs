using System.ComponentModel.DataAnnotations;

namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Usuário de Login View Model
    /// </summary>
    public class UsuarioDeLoginDTO
    {
        /// <summary>
        /// Email do usuário
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
    }
}
