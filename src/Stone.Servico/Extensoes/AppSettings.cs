namespace Stone.Servico.Extensoes
{
    /// <summary>
    /// Classe para receber as informações do appSettings.json
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Secret
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// Tempo de expiração
        /// </summary>
        public int ExpiracaoHoras { get; set; }
        /// <summary>
        /// Emissor
        /// </summary>
        public string Emissor { get; set; }

        /// <summary>
        /// Validade
        /// </summary>
        public string ValidoEm { get; set; }
    }
}
