using System.ComponentModel;

namespace Stone.Dominio.Enums
{
    /// <summary>
    /// Enumerador do Status da transação
    /// </summary>
    public enum EStatusDaTransacao : int
    {
        /// <summary>
        /// Aguardando Processamento
        /// </summary>
        [Description("Aguardando Processamento")]
        AguardandoProcessamento = 1,

        /// <summary>
        /// Processada
        /// </summary>
        [Description("Processada")]
        Processada = 2,

        /// <summary>
        /// Aprovada
        /// </summary>
        [Description("Aprovada")]
        Aprovada = 3,

        /// <summary>
        /// Recusada
        /// </summary>
        [Description("Recusada")]
        Recusada = 4,
    }
}
