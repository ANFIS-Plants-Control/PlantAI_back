
using Application.DTOs.MQTT.Topic;

namespace Application.DTOs.MQTT.Subscriptions
{
    public record ResponseMqttClientDto(string ClientId, int topicId, int brokerId, DateTime LastMessageDateTime);
    public record ReponseMqttClientWithTopicDto(string ClientId, ResponseMqttTopic topic, DateTime LastMessageDateTime);
}
