namespace Core.Models.mqtt
{
    public class TopicDefinition
    {
        public int Id { get; set; }
        public string Topic { get; set; }
        public ICollection<MqttClient> Subscriptions { get; set; }
    }
}
