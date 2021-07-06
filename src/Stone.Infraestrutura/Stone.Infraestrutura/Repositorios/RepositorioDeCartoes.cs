using Stone.Dominio.Classes;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Infraestrutura.Contextos;
using Stone.Infraestrutura.Repositorios.Base;

namespace Stone.Infraestrutura.Repositorios
{
    /// <summary>
    /// Repositório da entidade cartão
    /// </summary>
    public class RepositorioDeCartoes : Repositorio<Cartao>, IRepositorioDeCartoes
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db">Contexto</param>
        public RepositorioDeCartoes(MeuDbContext db) : base (db)
        {

        }
    }
}
