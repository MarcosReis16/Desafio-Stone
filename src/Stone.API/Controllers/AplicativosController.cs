using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Stone.API.Controllers.Base;
using Stone.Dominio.DTO;
using Stone.Servico.Interfaces;
using Stone.Utilitarios.Constantes;
using Stone.Utilitarios.Filtros.Excecao;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.API.Controllers
{
    /// <summary>
    /// Controller de Aplicativos
    /// </summary>
    [Route("api/[controller]")]
    public class AplicativosController : MainController
    {
        /// <summary>
        /// Instância do serviço de aplicativos
        /// </summary>
        private readonly IServicoDeAplicativos _servicoDeAplicativos;

        /// <summary>
        /// Cache de memória
        /// </summary>
        private readonly IMemoryCache _cache;


        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="servicoDeAplicativos">Instância do serviço de aplicativos</param>
        /// <param name="cache">Cache de memória</param>
        public AplicativosController(IServicoDeAplicativos servicoDeAplicativos,
                                     IMemoryCache cache)
        {
            _servicoDeAplicativos = servicoDeAplicativos;
            _cache = cache;
        }

        /// <summary>
        /// Endpoint responsável por obter todos os aplicativos
        /// </summary>
        /// <returns>Lista de aplicativos</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErroResposta), StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            if (_cache.TryGetValue(Constantes.APLICATIVOS_KEY, out IEnumerable<AplicativoDTO> aplicativos))
                return Ok(aplicativos);

            aplicativos = await _servicoDeAplicativos.ObterTodos();

            MemoryCacheEntryOptions memoryCacheEntryOptions = new()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30),
                SlidingExpiration = TimeSpan.FromMinutes(10)
            };

            _cache.Set(Constantes.APLICATIVOS_KEY, aplicativos, memoryCacheEntryOptions);

            return Ok(aplicativos);
        }
    }
}
