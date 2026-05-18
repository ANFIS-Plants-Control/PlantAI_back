namespace Infrastructure.MQTTOptions
{
    public class MQTTOptions
    {
        public string Host { get; init; }
        public int Port { get; init; }
        public string ClientId { get; init; }
        public string Topic { get; init; }
    }
}