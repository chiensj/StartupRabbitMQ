using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

internal class Program
{
    private static void Main(string[] args)
    {
        var factory = new ConnectionFactory() { HostName="192.168.1.101" };
        using ( var connection = factory.CreateConnection() )
        using ( var channel = connection.CreateModel() )
        {
            channel.QueueDeclare("BasicTest", false, false, false, null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea)=> 
            {
                byte[] body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine("Receive message {0}", message);
            };

            channel.BasicConsume("BasicTest", true, consumer);

            Console.WriteLine("Press [Enter] to exit the Consumer...");
            Console.ReadLine();
        }
    }
}