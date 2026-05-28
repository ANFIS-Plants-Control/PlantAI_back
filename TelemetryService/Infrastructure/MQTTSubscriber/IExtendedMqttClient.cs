using MQTTnet;

namespace Infrastructure.MQTTSubscriber
{
    public interface IExtendedMqttClient : IMqttClient
    {
        public bool IsSubscribed { get; set; }

    }
}
