using FluentValidation;
using Stone.Dominio.DTO;

namespace Stone.Dominio.Validation
{
    /// <summary>
    /// Classe de validação de usuário de registro
    /// </summary>
    public class UsuarioDeRegistroValidation : AbstractValidator<UsuarioDeRegistroDTO>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public UsuarioDeRegistroValidation()
        {
            RuleFor(u => u.Cpf)
                .NotEmpty().WithMessage("O campo {0} é obrigatório")
                .Length(11).WithMessage("O campo {0} precisa ter entre {2} e {1} caracteres");

            RuleFor(u => u.Nome)
                .NotEmpty().WithMessage("O campo {0} é obrigatório");

            RuleFor(u => u.Password)
                .NotEmpty().WithMessage("O campo {0} é obrigatório");

            RuleFor(u => new UsuarioDeRegistroDTO { ConfirmPassword = u.ConfirmPassword, Password = u.Password })
                .Must(a => a.ConfirmPassword == a.Password).WithMessage("As senhas não conferem.");

            RuleFor(u => u.DataDeNascimento)
                .NotEmpty().WithMessage("O campo {0} é obrigatório");

            RuleFor(u => u.Sexo)
                .NotEmpty().WithMessage("O campo {0} é obrigatório");


        }
    }
}
