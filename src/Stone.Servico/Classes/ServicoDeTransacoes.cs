﻿using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Stone.Dominio.Classes;
using Stone.Dominio.DTO;
using Stone.Dominio.Excecoes;
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
        /// Repositório de Cartões
        /// </summary>
        private readonly IRepositorioDeCartoes _repositorioDeCartoes;

        /// <summary>
        /// Repositório de aplicativos
        /// </summary>
        private readonly IRepositorioDeAplicativos _repositorioDeAplicativos;

        /// <summary>
        /// Administrador de usuário
        /// </summary>
        private readonly UserManager<Usuario> _userManager;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorioDeTransacoes">Instância de um repositório de transações</param>
        /// <param name="repositorioDeCartoes">Instância de um repositório de cartões</param>
        /// <param name="repositorioDeAplicativos">Instância de um repositório de aplicativos</param>
        /// <param name="userManager">User Manager</param>
        /// <param name="mapper">Mapper</param>
        /// <param name="logger">Logger</param>
        public ServicoDeTransacoes(IRepositorioDeTransacoes repositorioDeTransacoes,
                                   IRepositorioDeCartoes repositorioDeCartoes,
                                   IRepositorioDeAplicativos repositorioDeAplicativos,
                                   UserManager<Usuario> userManager,
                                   IMapper mapper, ILogger<ServicoDeTransacoes> logger) : base (mapper, logger)
        {
            _repositorioDeTransacoes = repositorioDeTransacoes;
            _repositorioDeCartoes = repositorioDeCartoes;
            _repositorioDeAplicativos = repositorioDeAplicativos;
            _userManager = userManager;
        }

        /// <summary>
        /// Adicionar
        /// </summary>
        /// <param name="transacao">Adicionar Transação DTO</param>
        public async Task Adicionar(AdicionarTransacaoDTO transacao)
        {
            var usuario = await _userManager.FindByIdAsync(transacao.IdUsuario.ToString());

            if (usuario == null) throw new ExcecaoDeNegocio(Mensagens.UsuarioNaoEncontrado);
            Cartao cartao = await ObterCartao(transacao);

            if (await _repositorioDeAplicativos.ObterPorId(transacao.IdAplicativo.Value) == null) throw new ExcecaoDeNegocio(Mensagens.AplicativoNaoEncontrado);

            if (!await _repositorioDeTransacoes.Adicionar(new Transacao(transacao, usuario, cartao)))
                throw new ExcecaoDeNegocio(Mensagens.FalhaAoAdicionarTransacao);

            _logger.LogInformation(Mensagens.IncluirTransacaoComSucesso);

        }

        /// <summary>
        /// Método para obter o cartão
        /// </summary>
        /// <param name="transacao">Adicionar Transação</param>
        /// <returns>Cartão</returns>
        private async Task<Cartao> ObterCartao(AdicionarTransacaoDTO transacao)
        {
            Cartao cartao;
            if (transacao.IdCartao != null)
            {
                cartao = await _repositorioDeCartoes.ObterPorId(transacao.IdCartao.Value);
                if (cartao == null) throw new ExcecaoDeNegocio(Mensagens.CartaoNaoEncontrado);
            }
            else
            {
                cartao = Cartao.Create(transacao.Cartao);
                if (!await _repositorioDeCartoes.Adicionar(cartao)) throw new ExcecaoDeNegocio(Mensagens.FalhaAoAdicionarTransacao);
            }

            return cartao;
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
        /// <param name="idDoUsuario">Id do usuário</param>
        /// <param name="idDoAplicativo">Id do aplicativo</param>
        /// <returns>Transacao</returns>
        public async Task<TransacaoDTO> ObterPorId(Guid idDoUsuario, Guid idDoAplicativo)
        {
            return _mapper.Map<TransacaoDTO>(await _repositorioDeTransacoes.ObterTransacaoAplicativoUsuarioCartao(idDoUsuario,idDoAplicativo));
        }

    }
}
