namespace Core.Models.mqtt
{
    public class MqttClient
    {

        public int Id { get; set; }
        public string ClientId { get; set; }
        public int TopicId { get; set; }
        public int BrokerId { get; set; }
        public TopicDefinition Topic { get; set; }
        public BrokerParpameters Broker { get; set; }
    }
}
