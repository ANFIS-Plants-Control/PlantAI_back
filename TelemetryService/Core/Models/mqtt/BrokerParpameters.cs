namespace Core.Models.mqtt
{
    public class BrokerParpameters
    {
        public int Id { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public ICollection<MqttClient> Clients { get; set; }
    }
}
