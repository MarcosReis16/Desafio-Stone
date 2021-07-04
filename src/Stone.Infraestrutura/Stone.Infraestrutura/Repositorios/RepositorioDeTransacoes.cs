using Stone.Dominio.Classes;
using Stone.Dominio.InterfacesDosRepositorios;
using System.Threading.Tasks;

namespace Stone.Infraestrutura.Repositorios
{
    /// <summary>
    /// Repositório de transações
    /// </summary>
    public class RepositorioDeTransacoes : IRepositorioDeTransacoes
    {
        /// <summary>
        /// Instância do repositório genérico para transações
        /// </summary>
        private readonly IRepositorio<Transacao> _repositorio;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorio">Instância do repositório genérico para transações</param>
        public RepositorioDeTransacoes(IRepositorio<Transacao> repositorio)
        {
            _repositorio = repositorio;
        }

        /// <summary>
        /// Método responsável por inserir uma transação
        /// </summary>
        /// <param name="transacao">Transação</param>
        /// <returns></returns>
        public async Task Adicionar(Transacao transacao)
        {
            await _repositorio.Adicionar(transacao);
        }
    }
}
