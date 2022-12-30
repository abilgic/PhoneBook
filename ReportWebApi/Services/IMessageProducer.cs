namespace ReportWebApi.Services
{    
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
