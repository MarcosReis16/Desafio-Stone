namespace Stone.Dominio.Classes
{
    /// <summary>
    /// Entidade responsável pelo cartão
    /// </summary>
    public class Cartao
    {
        /// <summary>
        /// Bandeira
        /// </summary>
        public string Bandeira { get; private set; }

        /// <summary>
        /// Nome do Titular
        /// </summary>
        public string NomeDoTitular { get; private set; }

        /// <summary>
        /// Número do Cartão
        /// </summary>
        public string Numero { get; private set; }

        /// <summary>
        /// Validade do Cartão
        /// </summary>
        public string Validade { get; private set; }

        /// <summary>
        /// Código de Segurança
        /// </summary>
        public string CodigoDeSeguranca { get; set; }
    }
}
