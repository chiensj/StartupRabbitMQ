using System.Text;
using RabbitMQ.Client;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var factory = new ConnectionFactory() { HostName="192.168.1.101" };
        using ( var connection = factory.CreateConnection() )
        using ( var channel = connection.CreateModel() )
        {
            Console.Write("write somethind , type Q! to exit!!");
            channel.QueueDeclare("BasicTest", false, false, false, null);
            string? message;
            do
            {
                message = Console.ReadLine()+"";
                byte[] body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish("", "BasicTest", null, body);
                Console.WriteLine("Send message {0}", message);
            } while ( message.ToUpper() != "Q!" );
        }
    }
}