namespace Application.DTOs.MqttClientOptions
{
    public record ResponseMqttClientOptionsDto(int Id, string ClientId, string Host, int Port, string Topic, bool IsSubscribed);
}
