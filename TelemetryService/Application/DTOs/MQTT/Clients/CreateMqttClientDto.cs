namespace Application.DTOs.MQTT.Subscriptions
{
    public record CreateMqttClientDto(string clientId, int brokerId);
}
