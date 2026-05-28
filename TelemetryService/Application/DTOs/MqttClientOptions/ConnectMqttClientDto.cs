namespace Application.DTOs.MqttClientOptions
{
    public record ConnectMqttClientDto(string ClientId, string Host, int Port);
}
