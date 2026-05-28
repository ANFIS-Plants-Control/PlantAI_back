namespace Core.Models
{
    public class MqttClientOptions
    {

        public int Id { get; init; }
        public string ClientId { get; init; }
        public string Host { get; init;  }
        public int Port { get; init; }  
        public string Topic { get; init; }

    }
}
