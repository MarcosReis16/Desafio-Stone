namespace Stone.Consumer.Serviço
{
    /// <summary>
    /// Interface do serviço de consumer
    /// </summary>
    public interface IServicoDeConsumer
    {
        /// <summary>
        /// Método responsável por processar transações da Fila
        /// </summary>
        /// <returns></returns>
        void Processar();
    }
}
