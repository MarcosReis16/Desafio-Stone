using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
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
        /// <summary>
        /// Método responsável por interceptar uma exceção e tratá-la antes de retornar para o endpoint
        /// </summary>
        /// <param name="context">Contexto da exceção</param>
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            if(context.Exception is ExcecaoDeNegocio)
            {
                ErroResposta obj = new ErroResposta(new List<string>() { context.Exception.Message }, context.Exception.StackTrace);
                MontarResposta(ref context, obj, HttpStatusCode.BadRequest);
            }
            else if (context.Exception is ExcecaoDeValidacao excecao && excecao.Falhas != null)
            {
                ErroResposta obj = new ErroResposta(excecao.Falhas, context.Exception.StackTrace);
                MontarResposta(ref context, obj, HttpStatusCode.BadRequest);
            }
            else
            {
                ErroResposta obj = new ErroResposta(new List<string>() { context.Exception.Message }, context.Exception.StackTrace);
                MontarResposta(ref context, obj, HttpStatusCode.InternalServerError);
            }
        }

        private void MontarResposta(ref ExceptionContext context, ErroResposta obj, HttpStatusCode code)
        {
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = (int)code;

            context.Result = new JsonResult(obj);
        }


    }
}
