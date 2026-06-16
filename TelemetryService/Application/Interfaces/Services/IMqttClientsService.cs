using Application.DTOs.MQTT.Clients;
using Application.DTOs.MQTT.Subscriptions;

namespace Application.Interfaces.Services
{
    public interface IMqttClientsService
    {
        public Task<IEnumerable<ResponseMqttClientDto>> GetMqttClientsAsync();
        public Task<IEnumerable<ReponseMqttClientWithTopicDto>> GetMqttClientsWithTopicsAsync();
        public Task<ResponseMqttClientDto> CreateMqttClientAsync(CreateMqttClientDto dto);
        public Task BindMqttClientTopicAsync(SubscribeMqttClientDto dto);
    }
}
