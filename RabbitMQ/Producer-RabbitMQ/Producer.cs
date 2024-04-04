using System.Net.Sockets;
using System.Text;
using RabbitMQ.Client;

var factory = new ConnectionFactory { HostName = "localhost" };
using var connection = factory.CreateConnection();
using var channel = connection.CreateModel();

channel.QueueDeclare(queue: "hello",
                     durable: false,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

int counter = 0;

do
{
    counter++;
    const string message = "Hello World!";
    string newMessage = message + " " + counter.ToString(); 
    var body = Encoding.UTF8.GetBytes(newMessage);

    channel.BasicPublish(exchange: string.Empty,
                         routingKey: "hello",
                         basicProperties: null,
                         body: body);
    Console.WriteLine($" [x] Sent {newMessage}");

    Console.WriteLine(" Do you want to send another message?");
    var op = Console.ReadLine();

    if(op != "yes")
    {
        break;
    }

} while (true);