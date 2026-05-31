using MQTTnet;

namespace Infrastructure.Extensions.mqtt
{
    public interface IExtendedMqttClient : IMqttClient
    {
        public bool IsSubscribed { get; set; }

    }
}
