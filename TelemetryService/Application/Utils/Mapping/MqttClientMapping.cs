
using Application.DTOs.MQTT;
using Application.DTOs.MQTT.Clients;
using Application.DTOs.MQTT.Subscriptions;
using Core.Models.mqtt;

namespace Application.Utils.Mapping
{
    public static class MqttClientMapping
    {
        public static MqttClient ToEntity(this CreateMqttClientDto dto) 
            => new MqttClient { ClientId = dto.clientId, TopicId = dto.topicId , BrokerId = dto.brokerId};

        public static ResponseMqttClientDto ToResponse(this MqttClient model) 
            => new ResponseMqttClientDto(model.ClientId, model.TopicId, model.BrokerId);
        public static ReponseMqttClientWithTopicDto ToResponseWithTopic(this MqttClient model)
            => new ReponseMqttClientWithTopicDto(model.ClientId, model.Topic.ToResponse());
        public static ResponseMqttDashboardDto ToDashboardResponse(this BrokerParpameters model)
            => new ResponseMqttDashboardDto(model.Id, model.Host, model.Port, model.Clients.Select(x => x.ToResponseWithTopic()));
    }
}
