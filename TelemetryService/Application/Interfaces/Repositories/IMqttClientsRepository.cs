using Core.Models.mqtt;

namespace Application.Interfaces.Repositories
{
    public interface IMqttClientsRepository
    {
        public Task<IEnumerable<MqttClient>> GetAsync();
        public Task CreateClientAsync(MqttClient options);
        public Task<MqttClient> GetByClientIdAsync(string clientId);
        public Task<MqttClient> GetByClientIdWithTopicsAsync(string clientId);
        public Task<IEnumerable<MqttClient>> GetClientsWithTopicsAsync();
        public Task<MqttClient> GetByIdAsync(int id);

    }
}
