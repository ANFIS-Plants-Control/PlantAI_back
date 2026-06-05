using Application.DTOs.MQTT.Subscriptions;

namespace Application.Interfaces.Services
{
    public interface IMqttClientsService
    {
        public Task<IEnumerable<ResponseMqttClientDto>> GetMqttClientsAsync();

        public Task<ResponseMqttClientDto> CreateMqttClientAsync(CreateMqttClientDto dto);
    }
}
