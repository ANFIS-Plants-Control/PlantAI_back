namespace Application.DTOs.DataGroup
{
    public record CreateDataGroupDto(DateTime date, int MqttClientId, int TopicId);
}
