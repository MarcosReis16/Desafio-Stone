namespace Stone.API.ViewModel
{
    /// <summary>
    /// Resposta do Login
    /// </summary>
    public class RespostaDoLoginViewModel
    {
        /// <summary>
        /// Token de acesso
        /// </summary>
        public string TokenDeAcesso { get; set; }

        /// <summary>
        /// Tempo de expiração
        /// </summary>
        public double TempoDeExpiracao { get; set; }

        /// <summary>
        /// Objeto Token de Usuário
        /// </summary>
        public TokenDeUsuarioViewModel TokenDeUsuario { get; set; }
    }
}
