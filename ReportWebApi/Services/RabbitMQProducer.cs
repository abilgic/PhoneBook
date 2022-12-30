using MongoDB.Bson.IO;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace ReportWebApi.Services
{
    public class RabbitMQProducer : IMessageProducer
    {
        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://yarpfcbp:7R6RjJmiw2mUn3borMTyY6K0jNFW5m7v@hawk.rmq.cloudamqp.com/yarpfcbp");
            var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("ReportQueue");
            string json = JsonSerializer.Serialize(message);       
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "ReportQueue", body: body);
        }
    }
}
