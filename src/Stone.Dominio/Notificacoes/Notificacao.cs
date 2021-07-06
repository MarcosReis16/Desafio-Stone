namespace Stone.Dominio.Notificacoes
{
    /// <summary>
    /// Classe de notificação
    /// </summary>
    public class Notificacao
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="mensagem">Mensagem</param>
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        /// <summary>
        /// Mensagem
        /// </summary>
        public string Mensagem { get; }
    }
}
