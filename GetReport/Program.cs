using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://yarpfcbp:7R6RjJmiw2mUn3borMTyY6K0jNFW5m7v@hawk.rmq.cloudamqp.com/yarpfcbp");
using var connection = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("ReportQueue", true, false, false);
var consumer = new EventingBasicConsumer(channel);
channel.BasicConsume("ReportQueue", true, consumer);
consumer.Received += Consumer_Received;
Console.ReadLine();

void Consumer_Received(object? sender, BasicDeliverEventArgs e)
{
    var body = e.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
    Console.WriteLine("Received Report:"+Encoding.UTF8.GetString(e.Body.ToArray()));
}


