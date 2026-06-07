
using Application.DTOs.MQTT.Topic;

namespace Application.DTOs.MQTT.Subscriptions
{
    public record ResponseMqttClientDto(int id, string ClientId, int brokerId);
    public record ReponseMqttClientWithTopicDto(int id, string ClientId, int brokerId, IEnumerable<ResponseMqttTopic> topicsLastMessageDateTime);
}
