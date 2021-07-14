using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Stone.Dominio.Classes;
using Stone.Dominio.Enums;
using Stone.Dominio.Excecoes;
using Stone.Dominio.InterfacesDosRepositorios;
using Stone.Utilitarios.Mensagens;
using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Stone.Consumer.Serviço
{
    /// <summary>
    /// Serviço de consumo
    /// </summary>
    public class ServicoDeConsumer
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
        public async Task Processar()
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
                        var message = Encoding.UTF8.GetString(ea.Body.ToArray());
                        Transacao transacao = JsonSerializer.Deserialize<Transacao>(message);
                        transacao.AlterarStatusDaTransacao(EStatusDaTransacao.Processada);
                        channel.BasicAck(ea.DeliveryTag, false);

                        if (!await _repositorioDeTransacoes.Adicionar(transacao))
                            throw new ExcecaoDeNegocio(Mensagens.FalhaAoAdicionarTransacao);
                    }
                    catch (Exception)
                    {
                        channel.BasicNack(ea.DeliveryTag, false, true);
                    }
                    finally
                    {
                        channel.BasicConsume(queue: "inserirTransacao",
                                             autoAck: false,
                                             consumer: consumer);
                    }
                };
            }
        }

    }
}
