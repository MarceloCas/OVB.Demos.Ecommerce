using OVB.Demos.Ecommerce.Microsservices.User.Domain.Contracts.Services.Messenger;
using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace OVB.Demos.Ecommerce.Microsservices.User.Services.Messenger;

public class MessengerService : IMessengerService
{
    private string HostnameService { get; }
    private string PasswordService { get; }
    private string UsernameService { get; }
    private string VirtualHostService { get; }
    private int PortService { get; }

    public MessengerService()
    {
        HostnameService = Environment.GetEnvironmentVariable("RABBITMQ_URL")!.ToString();
        PasswordService = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD")!.ToString();
        UsernameService = Environment.GetEnvironmentVariable("RABBITMQ_USERNAME")!.ToString();
        VirtualHostService = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST")!.ToString();
        PortService = 5672;
    }

    public void ReceiveMessage(string queue)
    {
        var connectionFactory = new ConnectionFactory()
        {
            HostName = HostnameService,
            Password = PasswordService,
            UserName = UsernameService,
            Port = PortService
        };

        using (var connection = connectionFactory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: queue,
                    durable: true,
                    exclusive: false,
                    autoDelete: true,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queue: queue, autoAck: true, consumer: consumer);
            }
        }
    }

    public void SendMessage(string queue, string message)
    {
        var connectionFactory = new ConnectionFactory()
        {
            VirtualHost = VirtualHostService,
            UserName = UsernameService,
            Password = PasswordService,
            HostName = HostnameService,
            Port = PortService
        };

        using (var connection = connectionFactory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: queue,
                    durable: true,
                    exclusive: false,
                    autoDelete: true,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
