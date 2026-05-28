namespace Application.DTOs.MqttClientOptions
{
    public record CreateMqttClientOptionsDto(string ClientId, string Host, int Port, string Topic);
}
