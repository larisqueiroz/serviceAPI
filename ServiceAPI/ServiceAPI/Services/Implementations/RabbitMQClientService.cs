using System.Text;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using ServiceAPI.Models.DTO;
using ServiceAPI.Services.Interfaces;
using IModel = RabbitMQ.Client.IModel;

namespace ServiceAPI.Services.Implementations;

public class RabbitMQClientService: IRabbitMQClientService
{
    public RabbitMQClientService()
    {
        IConnection? connection = null;
        IModel? channel = null;

        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            Port = 15672,
            UserName = "guest",
            Password = "guest",
            ClientProvidedName = "serviceAPI",
        };

        while (true)
        {
            try
            {
                connection = factory.CreateConnection();
                channel = connection.CreateModel();
            }
            catch (ConnectFailureException)
            {
                Console.WriteLine("Tentativa de conexão falhou.");
            }
            if (channel is null) continue;
            break;
        }

        channel.QueueDeclare(queue: "serviceAPI", durable: default, exclusive: false, autoDelete: false,
            arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            var order = JsonSerializer.Deserialize<MessageReceived>(message);
            Console.WriteLine("[NOVO PEDIDO]: " + message);
        };

        channel.BasicConsume(queue: "serviceAPI", autoAck: true, consumer: consumer);
    }
    
}