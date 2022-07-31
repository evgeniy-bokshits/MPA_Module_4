using System.Text;
using RabbitMQ.Client;

using BLL.Interfaces;

namespace BLL.Implementations;

public class MessageService : IMessageService
{
    private const string HostName = "localhost";
    private const string QueueName = "Products";

    public static readonly Queue<string> UnsentMessages = new Queue<string>();

    public void Send(string message)
    {
        var factory = new ConnectionFactory() { HostName = HostName };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: QueueName,
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            channel.ConfirmSelect();

            var messageProperties = channel.CreateBasicProperties();
            messageProperties.Persistent = true;

            var body = Encoding.UTF8.GetBytes(message);

            channel.BasicPublish(exchange: "",
                                 routingKey: QueueName,
                                 mandatory: true,
                                 basicProperties: null,
                                 body: body);

            channel.BasicPublish("", QueueName, messageProperties, body);

            channel.WaitForConfirmsOrDie();
        }
    }
}
