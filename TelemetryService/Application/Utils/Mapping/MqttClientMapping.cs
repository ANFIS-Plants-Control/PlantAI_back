using Application.DTOs.MQTT.Clients;
using Application.DTOs.MQTT.Subscriptions;
using Core.Models.mqtt;

namespace Application.Utils.Mapping
{
    public static class MqttClientMapping
    {
        public static MqttClient ToEntity(this CreateMqttClientDto dto) 
            => new MqttClient { ClientId = dto.clientId, TopicId = dto.topicId , BrokerId = dto.brokerId, LastMessageDateTime = DateTime.UtcNow};
        public static ResponseMqttClientDto ToResponse(this MqttClient model) 
            => new ResponseMqttClientDto(model.ClientId, model.TopicId, model.BrokerId, model.LastMessageDateTime);
        public static ReponseMqttClientWithTopicDto ToResponseWithTopic(this MqttClient model)
            => new ReponseMqttClientWithTopicDto(model.Id, model.ClientId, model.Topic.ToResponse(), model.LastMessageDateTime);
    }
}
