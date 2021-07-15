using FluentValidation;
using Stone.Dominio.DTO;

namespace Stone.Dominio.Validation
{
    /// <summary>
    /// Classe de validação do Adicionar Transação
    /// </summary>
    public class AdicionarTransacaoValidation : AbstractValidator<AdicionarTransacaoDTO>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public AdicionarTransacaoValidation()
        {
            RuleFor(t => t.IdUsuario)
                .NotEmpty().WithMessage("É necessário informar o identificador do usuário.");

            RuleFor(t => t.IdAplicativo)
                .NotEmpty().WithMessage("É necessário informar o identificador do aplicativo.");
            
            
        }
    }
}
