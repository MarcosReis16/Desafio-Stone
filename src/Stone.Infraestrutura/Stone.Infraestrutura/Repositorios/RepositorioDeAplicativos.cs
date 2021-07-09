using Stone.Dominio.Classes;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Infraestrutura.Contextos;
using Stone.Infraestrutura.Repositorios.Base;

namespace Stone.Infraestrutura.Repositorios
{
    /// <summary>
    /// Repositório de aplicativos
    /// </summary>
    public class RepositorioDeAplicativos : Repositorio<Aplicativo>, IRepositorioDeAplicativos
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db">Contexto</param>
        public RepositorioDeAplicativos(MeuDbContext db) : base (db)
        {

        }
    }
}
