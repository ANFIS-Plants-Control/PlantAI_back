namespace Application.DTOs.MQTT.Subscriptions
{
    public record ConnectMqttClientDto(string clientId, string host, int port);
}
