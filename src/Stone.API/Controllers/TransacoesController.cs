using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stone.API.Controllers.Base;
using Stone.Dominio.DTO;
using Stone.Servico.Interfaces;
using Stone.Utilitarios.Filtros.Excecao;
using System;
using System.Threading.Tasks;

namespace Stone.API.Controllers
{
    /// <summary>
    /// Transações Controller
    /// </summary>
    [Route("api/transacoes")]
    [ApiController]
    [Authorize]
    public class TransacoesController : MainController
    {
        /// <summary>
        /// Serviço de transações
        /// </summary>
        private readonly IServicoDeTransacoes _servicoDeTransacoes;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoDeTransacoes">Serviço de Transações</param>
        public TransacoesController(IServicoDeTransacoes servicoDeTransacoes)
        {
            _servicoDeTransacoes = servicoDeTransacoes;
        }

        /// <summary>
        /// Endpoint responsável por adicionar uma transação
        /// </summary>
        /// <param name="transacao">Transação</param>
        /// <returns>Resultado da operação</returns>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status500InternalServerError)]
        [HttpPost]
        public async Task<IActionResult> Adicionar(AdicionarTransacaoDTO transacao)
        {
            if(await _servicoDeTransacoes.Adicionar(transacao))
                return Created(nameof(Adicionar), null);
            return BadRequest();
        }

        /// <summary>
        /// Endpoint responsável por obter todas as transações
        /// </summary>
        /// <returns>Lista com todas as transações</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _servicoDeTransacoes.ObterTodos());
        }

        /// <summary>
        /// Endpoint responsável por obter uma transação por Id
        /// </summary>
        /// <returns>Transação</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await _servicoDeTransacoes.ObterPorId(id));
        }

    }
}
