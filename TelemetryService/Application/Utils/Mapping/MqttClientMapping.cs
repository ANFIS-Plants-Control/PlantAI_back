using Application.DTOs.MQTT.Clients;
using Application.DTOs.MQTT.Subscriptions;
using Core.Models.mqtt;

namespace Application.Utils.Mapping
{
    public static class MqttClientMapping
    {
        public static MqttClient ToEntity(this CreateMqttClientDto dto) 
            => new MqttClient { ClientId = dto.clientId, BrokerId = dto.brokerId};
        public static ResponseMqttClientDto ToResponse(this MqttClient model) 
            => new ResponseMqttClientDto(model.Id, model.ClientId,  model.BrokerId);
        public static ReponseMqttClientWithTopicDto ToResponseWithTopic(this MqttClient model)
            => new ReponseMqttClientWithTopicDto(model.Id, model.ClientId,model.BrokerId, model.Topics.Select(x => x.ToResponse()));
    }
}
