using System.Collections.Generic;

namespace Stone.Utilitarios.Filtros.Excecao
{
    /// <summary>
    /// Classe para retornar a excecao
    /// </summary>
    public class ErroResposta
    {
        /// <summary>
        /// Lista de erros
        /// </summary>
        public IList<string> Erros { get; set; }

        /// <summary>
        /// Stack
        /// </summary>
        public string Stack { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="excecoes">Lista de excecoes</param>
        /// <param name="stack">Stack</param>
        public ErroResposta(IList<string> excecoes, string stack)
        {
            Erros = excecoes;
            Stack = stack;
        }
    }
}
