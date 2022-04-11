using System;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
namespace Subscriber
{
    class Program
    {
    
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddFilter("System", LogLevel.Warning)
                    .AddFilter("NonHostConsoleApp.Program", LogLevel.Debug)
                    .AddConsole();
            });
            ILogger logger = loggerFactory.CreateLogger<Program>();
            try
            {
                ConnectionFactory factory;
                Console.WriteLine("Listening to message from Rabbit MQ ...");
                factory = new ConnectionFactory() { HostName = "rabbitmq", Port = 5672 };
                factory.UserName = "guest";
                factory.Password = "guest";
                var connection = factory.CreateConnection();
                logger.LogInformation("connected to the rabbit mq host");
                using var channel = connection.CreateModel();
                channel.QueueDeclare("orders", exclusive: false);
              
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, eventArgs) =>
                {
                    var body = eventArgs.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);

                    Console.WriteLine($"Message received: {message}");
                };

                channel.BasicConsume(queue: "orders", autoAck: true, consumer: consumer);
                logger.LogInformation("Consume from order queue on rabbit mq");
                Console.ReadKey();
                Console.WriteLine("Exit from Subscriber ...");

            }
            catch (Exception ex)
            {

                logger.LogError($"in rabbit mq: {ex.Message}");
            }

        }
    }
}
