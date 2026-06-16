namespace Core.Models.mqtt
{
    public class MqttClient
    {
        public int Id { get; set; }
        public string ClientId { get; set; }
        public int BrokerId { get; set; }
        public List<TopicDefinition> Topics { get; set; }
        public BrokerParpameters Broker { get; set; }
        public IEnumerable<DataGroup> DataGroups { get; set; }
    }
}
