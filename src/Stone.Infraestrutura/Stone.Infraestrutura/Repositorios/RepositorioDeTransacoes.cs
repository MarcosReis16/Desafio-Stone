using Stone.Dominio.Classes;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Infraestrutura.Contextos;
using Stone.Infraestrutura.Repositorios.Base;

namespace Stone.Infraestrutura.Repositorios
{
    /// <summary>
    /// Repositório de transações
    /// </summary>
    public class RepositorioDeTransacoes : Repositorio<Transacao>, IRepositorioDeTransacoes
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public RepositorioDeTransacoes(MeuDbContext db) : base (db)
        {

        }

    }
}
