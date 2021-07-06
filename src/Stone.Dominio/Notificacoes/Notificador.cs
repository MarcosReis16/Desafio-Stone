using Stone.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Stone.Dominio.Notificacoes
{
    /// <summary>
    /// Classe notificadora
    /// </summary>
    public class Notificador : INotificador
    {
        /// <summary>
        /// Lista de notificações
        /// </summary>
        private IList<Notificacao> _notificacoes;

        /// <summary>
        /// Construtor
        /// </summary>
        public Notificador()
        {
            _notificacoes = new List<Notificacao>();
        }

        /// <summary>
        /// Método para adicionar as notificações
        /// </summary>
        /// <param name="notificacao">Objeto da notificação</param>
        public void Handle(Notificacao notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        /// <summary>
        /// Método para obter a lista de notificações
        /// </summary>
        /// <returns>Lista de notificações</returns>
        public IList<Notificacao> ObterNotificacoes()
        {
            return _notificacoes;
        }

        /// <summary>
        /// Método para verificar se há notificações
        /// </summary>
        /// <returns>Confirmação de notificação</returns>
        public bool TemNotificacao()
        {
            return _notificacoes.Any();
        }
    }
}
