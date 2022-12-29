using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var factory = new ConnectionFactory();

using var connection = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("ReportQueue", true, false, false);
var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume("ReportQueue", true, consumer);
consumer.Received += Consumer_Received;
Console.ReadLine();

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    Console.WriteLine("Received Report:"+Encoding.UTF8.GetString(e.Body.ToArray()));
}


