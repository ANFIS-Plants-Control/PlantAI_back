namespace Core.Models.mqtt
{
    public class TopicDefinition
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public List<MqttClient> Subscriptions { get; set; }
        public List<DataGroup> DataGroups { get; set; }
    }
}
