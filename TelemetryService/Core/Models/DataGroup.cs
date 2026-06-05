using Core.Models.mqtt;

namespace Core.Models
{
    public class DataGroup
    {

        public int Id { get; set; }
        public DateTime GroupDate { get; set; }
        public int MqttClientId { get; set; }
        public IEnumerable<SensorData> SensorsData { get; set; }
        public MqttClient MqttClient { get; set; }
    }
}
