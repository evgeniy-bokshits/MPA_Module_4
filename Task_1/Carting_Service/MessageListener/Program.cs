using System.Text;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

public class Program
{
    private const string HostName = "localhost";
    private const string QueueName = "Products";

    static void Main()
    {
        while (true)
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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    if (!string.IsNullOrEmpty(message))
                    {
                        // update items.
                    }
                };

                channel.BasicConsume(queue: QueueName,
                                     autoAck: true,
                                     consumer: consumer);
            }

            Thread.Sleep(2000);
        }
    }
}