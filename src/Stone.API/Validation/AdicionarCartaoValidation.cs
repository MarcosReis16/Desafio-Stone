using FluentValidation;
using Stone.Dominio.DTO;

namespace Stone.Dominio.Validation
{
    /// <summary>
    /// Validador do Adicionar Cartão
    /// </summary>
    public class AdicionarCartaoValidation : AbstractValidator<AdicionarCartaoDTO>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AdicionarCartaoValidation()
        {
            RuleFor(c => c.Bandeira)
                .NotEmpty().WithMessage("É necessário informar a bandeira do cartão.");

            RuleFor(c => c.CodigoDeSeguranca)
                .NotEmpty().WithMessage("É necessário informar o código de segurança do cartão.")
                .Length(3).WithMessage("O tamanho do campo é de 3 dígitos");

            RuleFor(c => c.NomeDoTitular)
                .NotEmpty().WithMessage("É necessário informar o nome do titular do cartão.");

            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("É necessário informar o número do cartão.")
                .Length(16).WithMessage("O número do cartão possui 16 dígitos.");

            RuleFor(c => c.Validade)
                .NotEmpty().WithMessage("É necessário informar a data de validade do cartão, incluindo o separador.")
                .Length(5).WithMessage("O campo aceita apenas 5 caracteres, incluindo o separador. MM/AA");

        }
    }
}
