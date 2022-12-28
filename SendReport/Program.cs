using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory();
factory.Uri = new Uri("amqps://yarpfcbp:7R6RjJmiw2mUn3borMTyY6K0jNFW5m7v@hawk.rmq.cloudamqp.com/yarpfcbp");
using var connection = factory.CreateConnection();
var channel = connection.CreateModel();
channel.QueueDeclare("ReportQueue", true, false, false);
var message = "Report prepared";
var body = Encoding.UTF8.GetBytes(message);
channel.BasicPublish(String.Empty, "ReportQueue", null, body);
Console.WriteLine("Hello");
Console.ReadLine();