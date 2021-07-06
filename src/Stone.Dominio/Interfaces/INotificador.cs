using Stone.Dominio.Notificacoes;
using System.Collections.Generic;

namespace Stone.Dominio.Interfaces
{
    /// <summary>
    /// Interface do notificador
    /// </summary>
    public interface INotificador
    {
        /// <summary>
        /// Verificador de notificações
        /// </summary>
        /// <returns>Confirmação</returns>
        bool TemNotificacao();

        /// <summary>
        /// Obter a lista de Notificações
        /// </summary>
        /// <returns>Lista de Notificações</returns>
        IList<Notificacao> ObterNotificacoes();

        /// <summary>
        /// Adicionar Notificações
        /// </summary>
        /// <param name="notificacao">Notificação</param>
        void Handle(Notificacao notificacao);
    }
}
