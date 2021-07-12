using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Stone.Servico.Interfaces;
using Stone.Utilitarios.Filtros.Excecao;
using System;
using System.Threading.Tasks;

namespace Stone.API.Controllers
{
    /// <summary>
    /// Controller responsável pelo Cartão
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CartaoController : ControllerBase
    {
        /// <summary>
        /// Instância do serviço de cartão
        /// </summary>
        private readonly IServicoDeCartao _servicoDeCartao;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoDeCartao">Serviço de Cartão</param>
        public CartaoController(IServicoDeCartao servicoDeCartao)
        {
            _servicoDeCartao = servicoDeCartao;
        }

        /// <summary>
        /// Endpoint responsável por trazer todos os cartões
        /// </summary>
        /// <returns>Lista de Cartões</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            return Ok(await _servicoDeCartao.ObterTodos());
        }

        /// <summary>
        /// Endpoint responsável por pegar o cartão pelo id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Cartão</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status500InternalServerError)]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> ObterPorId(Guid id)
        {
            return Ok(await _servicoDeCartao.ObterPorId(id));
        }
    }
}
