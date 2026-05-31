using Application.DTOs.MQTT.Topic;
using Core.Models.mqtt;

namespace Application.Utils.Mapping
{
    public static class TopicDefinitionMapping
    {

        public static ResponseMqttTopic ToResponse(this TopicDefinition entity)
            => new ResponseMqttTopic(entity.Id, entity.Topic); 

    }
}
