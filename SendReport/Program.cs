using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();

using var connection = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("ReportQueue", true, false, false);
var message = "Report prepared";
var body = Encoding.UTF8.GetBytes(message);
channel.BasicPublish(String.Empty, "ReportQueue", null, body);
Console.WriteLine("Hello");
Console.ReadLine();