using AutoMapper;
using Microsoft.Extensions.Logging;
using Stone.Dominio.Classes;
using Stone.Dominio.DTO;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Servico.Base;
using Stone.Servico.Interfaces;
using Stone.Utilitarios.Mensagens;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Servico.Classes
{
    /// <summary>
    /// Serviço de Transações
    /// </summary>
    public class ServicoDeTransacoes : ServicoBase, IServicoDeTransacoes
    {
        /// <summary>
        /// Repositório de Transações
        /// </summary>
        private readonly IRepositorioDeTransacoes _repositorioDeTransacoes;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorioDeTransacoes">Instância de um repositório de transações</param>
        /// <param name="mapper">Mapper</param>
        public ServicoDeTransacoes(IRepositorioDeTransacoes repositorioDeTransacoes,
                                   IMapper mapper, ILogger<ServicoDeTransacoes> logger) : base (mapper, logger)
        {
            _repositorioDeTransacoes = repositorioDeTransacoes;
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="transacao">Adicionar Transação DTO</param>
        /// <returns>Confirmação</returns>
        public async Task<bool> Adicionar(AdicionarTransacaoDTO transacao)
        {
            if (await _repositorioDeTransacoes.Adicionar(Transacao.Create(transacao)))
            {
                _logger.LogInformation(Mensagens.IncluirTransacaoComSucesso);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Obter Todos
        /// </summary>
        /// <returns>Lista de Transações DTO</returns>
        public async Task<IEnumerable<TransacaoDTO>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<TransacaoDTO>>(await _repositorioDeTransacoes.ObterTodos());
        }

        /// <summary>
        /// Obter por Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Transacao</returns>
        public async Task<TransacaoDTO> ObterPorId(Guid id)
        {
            return _mapper.Map<TransacaoDTO>(await _repositorioDeTransacoes.ObterPorId(id));
        }
    }
}
