using AutoMapper;
using Stone.Dominio.Classes;
using Stone.Dominio.DTO;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Servico.Base;
using Stone.Servico.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stone.Servico.Classes
{
    /// <summary>
    /// Serviço responsável pela entidade usuário
    /// </summary>
    public class ServicoDeUsuario : ServicoBase, IServicoDeUsuario
    {
        /// <summary>
        /// Instância do repositório de usuário
        /// </summary>
        private readonly IRepositorioDeUsuario _repositorioDeUsuario;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mapper">Instância do mapeador</param>
        /// <param name="repositorioDeUsuario">Instância do repositório de usuário</param>
        public ServicoDeUsuario(IMapper mapper, 
                                IRepositorioDeUsuario repositorioDeUsuario) : base (mapper)
        {
            _repositorioDeUsuario = repositorioDeUsuario;
        }
        /// <summary>
        /// Método para adicionar um usuário
        /// </summary>
        /// <param name="usuario">Usuário</param>
        /// <returns></returns>
        public async Task Adicionar(UsuarioDTO usuario)
        {
            await _repositorioDeUsuario.Adicionar(_mapper.Map<Usuario>(usuario));
        }

        /// <summary>
        /// Método responsável por atualizar um usuário
        /// </summary>
        /// <param name="entity">Usuário</param>
        /// <returns></returns>
        public async Task Atualizar(UsuarioDTO usuario)
        {
            await _repositorioDeUsuario.Atualizar(_mapper.Map<Usuario>(usuario));
        }

        /// <summary>
        /// Método responsável por obter um usuário por Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Usuário</returns>
        public async Task<UsuarioDTO> ObterPorId(Guid id)
        {
            return _mapper.Map<UsuarioDTO>(await _repositorioDeUsuario.ObterPorId(id));
        }

        /// <summary>
        /// Método responsável por obter uma lista com todos os usuários
        /// </summary>
        /// <returns>Lista de usuários</returns>
        public async Task<IEnumerable<UsuarioDTO>> ObterTodos()
        {
            var retorno = await _repositorioDeUsuario.ObterTodos();

            return retorno.Select(u => _mapper.Map<UsuarioDTO>(u));
        }

        /// <summary>
        /// Método responsável por obter um usuário com seu endereço, transações e cartões salvos através do Id
        /// </summary>
        /// <param name="id">Identificador da entidade</param>
        /// <returns>Usuário com Endereço, Transações e Cartões</returns>
        public async Task<UsuarioDTO> ObterUsuarioEnderecoTransacoesCartoesPorId(Guid id)
        {
            return _mapper.Map<UsuarioDTO>(await _repositorioDeUsuario.ObterUsuarioEnderecoTransacoesCartoesPorId(id));
        }

        /// <summary>
        /// Método responsável por remover um usuário
        /// </summary>
        /// <param name="id">Identificador do usuário</param>
        /// <returns></returns>
        public async Task Remover(Guid id)
        {
            await _repositorioDeUsuario.Remover(id);
        }
    }
}
