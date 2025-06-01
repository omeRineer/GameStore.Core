using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Business.Services.Internal
{
    public class RabbitMqClientService
    {
        readonly IChannel Channel;

        public RabbitMqClientService(IChannel channel)
        {
            Channel = channel;
        }


        public async Task PushAsync<TMessage>(string queueName, TMessage message, string exchange = "")
        {
            await Channel.QueueDeclareAsync(queueName,
                                      durable: true,
                                      exclusive: false,
                                      autoDelete: false,
                                      arguments: null);


            var serializedMessage = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(serializedMessage);

            await Channel.BasicPublishAsync(exchange, queueName, body);
        }
    }
}
