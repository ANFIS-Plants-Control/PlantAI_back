using Application.DTOs.MqttClientOptions;
using Core.Models;

namespace Application.Utils.Mapping
{
    public static class MqttClientOptionsMapping
    {

        public static MqttClientOptions ToEntity(this ResponseMqttClientOptionsDto dto) 
            => new MqttClientOptions { ClientId = dto.ClientId, Host=dto.Host, Port = dto.Port, Topic = dto.Topic };

        public static MqttClientOptions ToEntity(this CreateMqttClientOptionsDto dto)
            => new MqttClientOptions { ClientId = dto.ClientId, Host = dto.Host, Port = dto.Port, Topic = dto.Topic };


        public static ResponseMqttClientOptionsDto ToResponseDto(this MqttClientOptions entity) 
            => new ResponseMqttClientOptionsDto (entity.Id, entity.ClientId, entity.Host, entity.Port, entity.Topic, entity.IsSubscribed);

        public static ConnectMqttClientDto ToConnectDto(this ResponseMqttClientOptionsDto dto)
            => new ConnectMqttClientDto(dto.ClientId, dto.Host, dto.Port);
    }
}
