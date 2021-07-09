using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Stone.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Stone.Utilitarios.Filtros.Excecao
{

    /// <summary>
    /// Tratamento de exceções
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiExcecaoFiltros : ExceptionFilterAttribute
    {
        private readonly ILogger _logger;

        public ApiExcecaoFiltros(ILogger<ApiExcecaoFiltros> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Método responsável por interceptar uma exceção e tratá-la antes de retornar para o endpoint
        /// </summary>
        /// <param name="context">Contexto da exceção</param>
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            string mensagemDeErro;

            if(context.Exception is ExcecaoDeNegocio)
            {
                mensagemDeErro = Mensagens.Mensagens.ErroDeNegocio;
                ErroResposta obj = new(new List<string>() { context.Exception.Message }, context.Exception.StackTrace);
                MontarResposta(ref context, obj, HttpStatusCode.BadRequest);
            }
            else if (context.Exception is ExcecaoDeValidacao excecao && excecao.Falhas != null)
            {
                mensagemDeErro = Mensagens.Mensagens.ErroDeValidacao;
                ErroResposta obj = new(excecao.Falhas, context.Exception.StackTrace);
                MontarResposta(ref context, obj, HttpStatusCode.BadRequest);
            }
            else
            {
                mensagemDeErro = Mensagens.Mensagens.ErroInterno;
                ErroResposta obj = new(new List<string>() { context.Exception.Message }, context.Exception.StackTrace);
                MontarResposta(ref context, obj, HttpStatusCode.InternalServerError);
            }
            _logger.LogError(context.Exception, mensagemDeErro);
        }

        private void MontarResposta(ref ExceptionContext context, ErroResposta obj, HttpStatusCode code)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;

            context.Result = new JsonResult(obj);
        }


    }
}
