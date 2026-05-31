using Application.DTOs.MQTT.Subscriptions;

namespace Application.DTOs.MQTT.Clients
{
    public record ResponseMqttDashboardDto(int id, string host, int port, IEnumerable<ReponseMqttClientWithTopicDto> clients);
}
