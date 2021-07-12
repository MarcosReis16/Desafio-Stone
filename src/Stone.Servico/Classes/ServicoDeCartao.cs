using AutoMapper;
using Microsoft.Extensions.Logging;
using Stone.Dominio.DTO;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Servico.Base;
using Stone.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Servico.Classes
{
    /// <summary>
    /// Serviço de Cartão
    /// </summary>
    public class ServicoDeCartao : ServicoBase, IServicoDeCartao
    {
        /// <summary>
        /// Instância de um repositório de cartões
        /// </summary>
        private readonly IRepositorioDeCartoes _repositorioDeCartoes;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorioDeCartoes">Repositório de Cartões</param>
        public ServicoDeCartao(IRepositorioDeCartoes repositorioDeCartoes,
                               IMapper mapper,
                               ILogger logger) : base (mapper, logger)
        {
            _repositorioDeCartoes = repositorioDeCartoes;
        }
        
        /// <summary>
        /// Obter todos os cartões
        /// </summary>
        /// <returns>Lista de cartões</returns>
        public async Task<IEnumerable<CartaoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CartaoDTO>>(await _repositorioDeCartoes.ObterTodos());
        }

        /// <summary>
        /// Obter por id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Cartão DTO</returns>
        public async Task<CartaoDTO> ObterPorId(Guid id)
        {
            return _mapper.Map<CartaoDTO>(await _repositorioDeCartoes.ObterPorId(id));
        }
    }
}
