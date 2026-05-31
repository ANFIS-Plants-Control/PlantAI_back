using Application.DTOs.MQTT.BrokerParameters;
using Core.Models.mqtt;

namespace Application.Utils.Mapping
{
    public static class MqttBrokerMapping
    {

        public static ResponseBrokerParametersDto ToResponse(this BrokerParpameters entity)
            => new ResponseBrokerParametersDto(entity.Id, entity.Host, entity.Port);

        public static BrokerParpameters ToEntity(this CreateBrokerParametersDto dto)
            => new BrokerParpameters { Host = dto.host, Port = dto.port };
    }
}
