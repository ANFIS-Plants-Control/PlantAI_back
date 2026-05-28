using Application.DTOs.MqttClientOptions;

namespace Application.Interfaces.Services
{
    public interface IMqttClientOptionsService
    {
        public Task<IEnumerable<ResponseMqttClientOptionsDto>> GetAsync();
        public Task<ResponseMqttClientOptionsDto> CreateClientAsync(CreateMqttClientOptionsDto dto);
        public Task<ResponseMqttClientOptionsDto> GetByClientIdAsync(string clientId);
        public Task<ResponseMqttClientOptionsDto> GetByIdAsync(int Id);
        public Task SetIsSubscribedClientAsync(string clientId, bool isSubscribed);
        public Task<IEnumerable<ResponseMqttClientOptionsDto>> GetSubscribedClientsAsync(IEnumerable<string> clientIds);
    }
}
