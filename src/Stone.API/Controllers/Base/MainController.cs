using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Stone.Dominio.Interfaces;
using Stone.Dominio.Notificacoes;
using System.Linq;

namespace Stone.API.Controllers.Base
{
    /// <summary>
    /// Controller base
    /// </summary>
    [ApiController]
    public abstract class MainController : ControllerBase
    {
        /// <summary>
        /// Notificador customizado
        /// </summary>
        private readonly INotificador _notificador;

        /// <summary>
        /// Construtor
        /// </summary>
        public MainController(INotificador notificador)
        {
            _notificador = notificador;
        }

        /// <summary>
        /// Método para verificar se uma operação é válida
        /// </summary>
        /// <returns>Confirmação</returns>
        protected bool OperacaoValida()
        {
            return !_notificador.TemNotificacao();
        }

        /// <summary>
        /// Resposta customizada
        /// </summary>
        /// <param name="result">Resultado da operacao</param>
        /// <returns>Resposta customizada</returns>
        protected IActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
            {
                return Ok(new
                {
                    success = true,
                    data = result
                });
            }

            return BadRequest(new
            {
                success = false,
                errors = _notificador.ObterNotificacoes()
                                     .Select(n => n.Mensagem)
            });
        }

        /// <summary>
        /// Resposta customizada
        /// </summary>
        /// <param name="modelState">Model State</param>
        /// <returns>Resposta Customizada</returns>
        protected IActionResult CustomResponse(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
            return CustomResponse();
        }

        /// <summary>
        /// Método para notificar model state inválida
        /// </summary>
        /// <param name="modelState">Model State</param>
        protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(errorMsg);
            }
        }

        /// <summary>
        /// Método para alimentar o notificador
        /// </summary>
        /// <param name="mensagem">Mensagem de erro</param>
        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }

    }
    
}
