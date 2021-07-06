namespace Stone.Dominio.DTO
{
    /// <summary>
    /// Resposta do Login
    /// </summary>
    public class RespostaDoLoginDTO
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
        public TokenDeUsuarioDTO TokenDeUsuario { get; set; }
    }
}
