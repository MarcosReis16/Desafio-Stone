using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stone.Dominio.Classes;
using Stone.Dominio.Enums;
using Stone.Dominio.InterfacesDosRepositorios;
using System;
using System.Text;
using System.Text.Json;

namespace Stone.Consumer.Serviço
{
    /// <summary>
    /// Serviço de consumo
    /// </summary>
    public class ServicoDeConsumer : IServicoDeConsumer
    {
        /// <summary>
        /// Instância de um repositório de transações
        /// </summary>
        private readonly IRepositorioDeTransacoes _repositorioDeTransacoes;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="repositorioDeTransacoes">Instância de um repositório de transações</param>
        public ServicoDeConsumer(IRepositorioDeTransacoes repositorioDeTransacoes)
        {
            _repositorioDeTransacoes = repositorioDeTransacoes;
        }

        /// <summary>
        /// Método responsável por processar transações da Fila
        /// </summary>
        /// <returns></returns>
        public void Processar()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "inserirTransacao",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += async (model, ea) =>
                {
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        Transacao transacao = JsonSerializer.Deserialize<Transacao>(message);
                        transacao.AlterarStatusDaTransacao(EStatusDaTransacao.Processada);

                        await _repositorioDeTransacoes.Adicionar(transacao);

                        channel.BasicAck(ea.DeliveryTag, false);
                    }
                    catch (Exception)
                    {
                        channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                    
                };
                channel.BasicConsume(queue: "inserirTransacao",
                                             autoAck: false,
                                             consumer: consumer);
            }
        }

    }
}
