using Core.Models.mqtt;

namespace Core.Models
{
    public class DataGroup
    {

        public int Id { get; set; }
        public DateTime GroupDate { get; set; }
        public int MqttClientId { get; set; }
        public int TopicId { get; set; }
        public IEnumerable<SensorData> SensorsData { get; set; }
        public MqttClient MqttClient { get; set; }
        public TopicDefinition Topic { get; set; }
    }
}
